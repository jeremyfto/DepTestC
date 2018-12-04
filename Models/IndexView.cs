using System.Collections.Generic;

namespace ExamCRetake.Models
{
    public class IndexView
    {
        public User FormUser;
        public List<User> AllUsers = new List<User>();
        public Activitys FormActivity;
        public List<Activitys> AllActivities = new List<Activitys>();
        public JoinAct FormJoinAct;
        public List<JoinAct> AllJoinActs = new List<JoinAct>();
        public string IDXID;
        public bool utilforloop;

    }
}