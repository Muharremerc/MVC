using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace ClassLibrary1
{
   public class Ac
    {
        public List<Userr>  getUserFriendListbyUserId(int id)
        {
            SMEntities db = new SMEntities();
            var friend = db.Userrs.Include("UserFriends").Where(x => x.Id == id).ToList();
            return friend;
               
        }
        public Userr Login(string username,string password)
        {

            SMEntities db = new SMEntities();
            var user = db.Userrs.Where(x => x.Username == username).Where(x => x.Password == password).FirstOrDefault();
            return user;
        }
        public Userr getUserbyId(int id)
        {
            SMEntities db = new SMEntities();
            var user = db.Userrs.FirstOrDefault(x => x.Id == id);
            return user;


        }
        //MY shared and comments
         public List<UserShared> getShared(List<int> id)
        {

            SMEntities db = new SMEntities();
            List<UserShared> userharedlist = new List<UserShared>();
            foreach (var item in id)
            {

                var shared = db.UserShareds.Include("SharedComments").Include("SharedComments.Userr").Where(x => x.UserId == item).ToList();

                foreach (var item2 in shared)
                {
                    userharedlist.Add(new UserShared
                    {
                    Id =item2.Id,
                    SharedComments=item2.SharedComments,
                    SharedDetails=item2.SharedDetails,
                    SharedTime=item2.SharedTime,
                    UserId=item2.UserId,
                    Userr=getUserbyId(Convert.ToInt32(item2.UserId)) as Userr
                    }
                    );
                }
            }
            return userharedlist;

        }
         public List<UserShared> getShared(int id)
        {

            SMEntities db = new SMEntities();
            List<UserShared> userharedlist = new List<UserShared>();
            

                var shared = db.UserShareds.Include("SharedComments").Include("SharedComments.Userr").Where(x => x.UserId == id).ToList();

                foreach (var item2 in shared)
                {
                    userharedlist.Add(new UserShared
                    {
                        Id = item2.Id,
                        SharedComments = item2.SharedComments,
                        SharedDetails = item2.SharedDetails,
                        SharedTime = item2.SharedTime,
                        UserId = item2.UserId,
                        Userr = getUserbyId(Convert.ToInt32(item2.UserId)) as Userr
                    }
                    );
                }
            
            return userharedlist;

        }

        public List<SharedComment> getCommentBySharedId(int id)
        {
            SMEntities db = new SMEntities();
            var commnet = db.SharedComments.Include("Userr").Where(x => x.SharedId == id).ToList();
            return commnet;


        }

        public SharedComment addNewComment(int id,int sharedid,string comment)
        {
            SMEntities db = new SMEntities();
            SharedComment sc = new SharedComment();
            sc.UserId = id;
            sc.SharedId = sharedid;
            sc.Comment=comment;
            db.SharedComments.Add(sc);
            db.SaveChanges();
            return sc;

        }

        public UserShared AddNewShared(string shared,int id,DateTime time)
        {
            SMEntities db = new SMEntities();
            UserShared us = new UserShared();
            us.SharedDetails = shared;
            us.UserId = id;
            us.SharedTime = time;
            db.UserShareds.Add(us);
            db.SaveChanges();
            return us;

        }
        public Userr CheckUsername(string friend)
        {
            SMEntities db = new SMEntities();
            var user = db.Userrs.FirstOrDefault(x => x.Name == friend);
            return user;

        }
        public UserFriend addNewFriend(int friendId,int userId)
        {

            SMEntities db = new SMEntities();
            UserFriend uf = new UserFriend();
            uf.FriendId = friendId;
            uf.UserId = userId;
            db.UserFriends.Add(uf);
            db.SaveChanges();
            return uf;
        }
        public UserFriend CheckFriend(int friendId, int userId)
            {
            SMEntities db = new SMEntities();
            var check = db.UserFriends.Where(x =>x.UserId==userId).Where(x=>x.FriendId==friendId).FirstOrDefault();
            return check;

        }

        public Userr addNewUser(string name, string surname, string username, string password)
        {
            SMEntities db = new SMEntities();
            var check = db.Userrs.Where(x => x.Name == name).Where(x => x.Username == username).FirstOrDefault();
            if (check ==null)
            {
                Userr u = new Userr();
                u.Name = name;
                u.Surname = surname;
                u.Password = password;
                u.Username = username;
                db.Userrs.Add(u);
                db.SaveChanges();
                return u;
            }
            else
            {
                return null;
            }
            
            

        }
    }
}
