using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamCRetake.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
namespace ExamCRetake.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
        public HomeController(Context contextModel){
            _context = contextModel;
        }
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("UserID") != null){
                Console.WriteLine(HttpContext.Session.GetInt32("UserID"));
            }
            IndexView ShowUsers = new IndexView();
            ShowUsers.AllUsers = _context.Users.ToList();
            return View(ShowUsers);
        }
        [Route("Register")]
        [HttpPost]
        public IActionResult Registration(User formUser){
            if(formUser.password != formUser.ConfirmPass){
                ModelState.AddModelError("Password","Passwords need to match");
            }
            if(_context.Users.Any(u => u.Email == formUser.Email)){
                ModelState.AddModelError("Email", "Email already in use");
            }
            if(ModelState.IsValid){
                _context.Users.Add(formUser);
                _context.SaveChanges();
                int uID = _context.Users.Last().userId;
                HttpContext.Session.SetInt32("UserID", uID);
                return RedirectToAction("Success");
            }
            else{
                IndexView RegErrors = new IndexView(){
                    FormUser = formUser,
                    AllUsers = _context.Users.ToList()
                };
                Console.WriteLine("Invalid Form Sent");
                Console.WriteLine(string.Join(',', ModelState));
                return View("index", RegErrors);
            }
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(User formUser){
            User ReturnedUser = _context.Users.FirstOrDefault(user => user.Email == formUser.Email);
            if(ReturnedUser == null){
                TempData["ErrorEmail"] = "Incorrect or invalid email. Please check your email or use our registration page to create a account";
                return RedirectToAction("Index");
            }
            else if (ReturnedUser.password != formUser.password){
                TempData["ErrorPass"] = "Incorrect or invalid password";
                TempData.Keep();
                return RedirectToAction("Index");
            }
            else if (ReturnedUser.password == formUser.password){
                HttpContext.Session.SetInt32("UserID", ReturnedUser.userId);
                return Redirect("Success");
            }
            else{
                return RedirectToAction("Index");
            }
        }
        [Route("Logout")]
        [HttpGet]
        public IActionResult LogOut(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

// ENDOFREG //

        [Route("Success")]
        [HttpGet]
        public IActionResult SuccessPage(){
            if(HttpContext.Session.GetInt32("UserID") != null){
                IndexView ShowPost = new IndexView();
                ShowPost.IDXID = HttpContext.Session.GetInt32("UserID").ToString();
                ShowPost.AllActivities = _context.Activities.Include(post => post.User).ToList();
                ShowPost.AllJoinActs = _context.JoinAct.Include(activity => activity.Activities).ThenInclude(user => user.User).ToList();
                ViewBag.AllLikedPost = new List<Int32>();
                foreach(JoinAct numb in _context.JoinAct.Where(a => a.userId == HttpContext.Session.GetInt32("UserID"))){
                    ViewBag.AllLikedPost.Add(numb.activityId);
                    Console.WriteLine(numb.activityId);
                }
                
                return View("Dashboard", ShowPost);
            }
            else{
                return RedirectToAction("Index");
            }
        }
        [Route("Success/new")]
        public IActionResult ActivityCrePage(){
            HttpContext.Session.GetInt32("UserID");
            return View("actCreator");
        }
        [Route("actCre")]
        [HttpPost]
        public IActionResult actCre(Activitys formActivity){
            if(ModelState.IsValid){
                User user = _context.Users.SingleOrDefault(u => u.userId == HttpContext.Session.GetInt32("UserID"));
                formActivity.User = user;
                formActivity.duration = formActivity.duration + " " + formActivity.timemeasure;
                _context.Activities.Add(formActivity);
                _context.SaveChanges();
                return Redirect("Success");
            }
            else{
                IndexView RegErrors = new IndexView(){
                    FormActivity = formActivity,
                    AllActivities = _context.Activities.Include(post => post.User).ToList()
                };
                Console.WriteLine("Invalid Form Sent");
                Console.WriteLine(string.Join(',', ModelState));
                return View("dashboard", RegErrors);
            }
        }
        [Route("join")]
        [HttpPost]
        public IActionResult LikePost(JoinAct formJoinAct){
            if(ModelState.IsValid){
                formJoinAct.User = _context.Users.SingleOrDefault(u => u.userId == formJoinAct.userId);
                formJoinAct.Activities = _context.Activities.SingleOrDefault(u => u.activityId == formJoinAct.activityId);
                _context.JoinAct.Add(formJoinAct);
                _context.SaveChanges();
                return RedirectToAction("SuccessPage");
                }
            else{
                Console.WriteLine("Something went wrong with liking");
                return RedirectToAction("SuccessPage");
            }
        }
        [Route("activity/{actID}")]
        [HttpGet]
        public IActionResult ViewActivity(int actID){
            IndexView ShowAct = new IndexView();
            ShowAct.AllActivities = _context.Activities.Where(u => u.activityId == actID).Include(post => post.User).ToList();
            ViewBag.Participants = new List<string>();
            foreach(JoinAct numb in _context.JoinAct.Where(a => a.activityId == actID)){
                User tempUser = _context.Users.SingleOrDefault(u => u.userId == numb.userId);
                ViewBag.Participants.Add(tempUser.FirstName);
            }
            return View("viewActivity",ShowAct);
        }





        //KEEPATBOTTOM//
    }
}