using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HomeModel_
    {
        public class HomeModel
        {
            public List<Shared> S { get; set; }
            public List<Friend> F { get; set; }
        }


        public class Shared
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Details { get; set; }
            public string Time { get; set; }
        }
        public class Friend
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }

        public class Comment
        {
            public int id { get; set; }
            public List<ClassLibrary1.Model.SharedComment> C { get; set; }

        }
        
    }
}