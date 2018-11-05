using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ClassLibrary1.Ac ac = new ClassLibrary1.Ac();
            var user = Session["User"] as ClassLibrary1.Model.Userr;
            if (Session["User"] != null)
            { 
            
            var friend = ac.getUserFriendListbyUserId(user.Id);
            
            
                Models.HomeModel_.HomeModel homemodel = new Models.HomeModel_.HomeModel();
            List<Models.HomeModel_.Friend> fr = new List<Models.HomeModel_.Friend>();
                List<int> idlist = new List<int>();
         foreach (var item in friend)
            {
                foreach (var item2 in item.UserFriends)
                {
                    ClassLibrary1.Model.Userr u = new ClassLibrary1.Model.Userr();
                    u = ac.getUserbyId(item2.FriendId.Value);
                    fr.Add(new Models.HomeModel_.Friend
                    {
                        Id=u.Id,
                        Name = u.Name,
                        Surname = u.Surname
                    });
                        idlist.Add(Convert.ToInt32(item2.FriendId));
               }
                    
            }

            List<WebApplication1.Models.HomeModel_.Shared> s = new List<Models.HomeModel_.Shared>();
            
           

            idlist.Add(user.Id);
            var test = ac.getShared(idlist);
            var newList = test.OrderByDescending(x => x.SharedTime).ToList();
                test = newList;

                foreach (var item in test)
            {

                    var a = item.SharedTime.ToString();
                    s.Add(new Models.HomeModel_.Shared
                    {
                        Id = item.Id,
                        Name = item.Userr.Name,
                        Surname = item.Userr.Surname,
                        Details = item.SharedDetails,
                        Time = a


                    }
                      );
                

            }
            homemodel.F = fr;
            homemodel.S = s;
           
            return View(homemodel);
            }
            else

            return View();
        }


        public ActionResult getComment(int id)
        {
            ClassLibrary1.Ac ac = new ClassLibrary1.Ac();
            var comment = ac.getCommentBySharedId(id);
            WebApplication1.Models.HomeModel_.Comment c = new Models.HomeModel_.Comment();
            c.C = comment;
            c.id = id;


            return PartialView("_getComment",c);

        }

        public ActionResult AddnewComment(int id,string comment)
        {
            ClassLibrary1.Ac ac = new ClassLibrary1.Ac();
            var u =Session["User"] as ClassLibrary1.Model.Userr;
            if(u!=null)
            {

                var s = ac.addNewComment(u.Id,id,comment);

            }
                       
            return Json("");

        }

        public JsonResult Login(string username,string password)
        {
            ClassLibrary1.Ac ac = new ClassLibrary1.Ac();
            var log = ac.Login(username, password);
           
            if(log==null)
            {
                Session["User"] = null;
                return Json("False");
            }
            else
            {
                Session["User"] = log;
                return Json("True");
            }
            
        }

        public JsonResult Shared(string shared)
        {
            ClassLibrary1.Ac ac = new ClassLibrary1.Ac();
            

            var u = Session["User"] as ClassLibrary1.Model.Userr;
            if (u != null)
            {

                DateTime time = DateTime.Now;
                var newshared = ac.AddNewShared(shared,u.Id, time);
                return Json(newshared);
            }
            return Json(null);

        }
        public JsonResult AddFriend(string friend)
        {
            ClassLibrary1.Ac ac = new ClassLibrary1.Ac();


            var u = Session["User"] as ClassLibrary1.Model.Userr;
            if (u != null)
            {
                if(friend!=u.Name)
                { 
                var check = ac.CheckUsername(friend);
                if(check != null)
                {
                    var check2 = ac.CheckFriend(check.Id, u.Id);
                    if(check2==null)
                    { 
                    var addFriend = ac.addNewFriend(check.Id, u.Id);
                        return Json("Successful");
                    }
                    else
                    {
                        return Json("Added");
                    }
                    
                }
                else
                {
                    return Json("There are not Username");

                }
                }
            }
            return Json(null);

        }
        
         public JsonResult AddNewUser(string name, string surname, string username, string password)
        {
            ClassLibrary1.Ac ac = new ClassLibrary1.Ac();
            var user = ac.addNewUser(name, surname, username, password);
            if(user!=null)
            {
                return Json("Successful");
            }
            else
            {
                return Json("Added");
            }

        }

       
        public ActionResult getFriendProfil(int id)
        {
            ClassLibrary1.Ac ac = new ClassLibrary1.Ac();
            var getShared = ac.getShared(id);
            var user = ac.getUserbyId(id);
            var friendList = ac.getUserFriendListbyUserId(id);


            Models.HomeModel_.HomeModel homemodel = new Models.HomeModel_.HomeModel();
            List<Models.HomeModel_.Friend> fr = new List<Models.HomeModel_.Friend>();
            List<int> idlist = new List<int>();
            foreach (var item in friendList)
            {
                foreach (var item2 in item.UserFriends)
                {
                    ClassLibrary1.Model.Userr u = new ClassLibrary1.Model.Userr();
                    u = ac.getUserbyId(item2.FriendId.Value);
                    fr.Add(new Models.HomeModel_.Friend
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Surname = u.Surname
                    });
                    idlist.Add(Convert.ToInt32(item2.FriendId));
                }

            }

            List<WebApplication1.Models.HomeModel_.Shared> s = new List<Models.HomeModel_.Shared>();



            idlist.Add(user.Id);
            var test = ac.getShared(idlist);
            var newList = test.OrderByDescending(x => x.SharedTime).ToList();
            test = newList;

            foreach (var item in test)
            {

                var a = item.SharedTime.ToString();
                s.Add(new Models.HomeModel_.Shared
                {
                    Id = item.Id,
                    Name = item.Userr.Name,
                    Surname = item.Userr.Surname,
                    Details = item.SharedDetails,
                    Time = a


                }
                  );


            }
            homemodel.F = fr;
            homemodel.S = s;

            return View(homemodel);
        }
    }
}