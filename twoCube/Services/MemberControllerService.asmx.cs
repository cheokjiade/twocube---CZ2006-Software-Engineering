using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.IO;
using twoCube.Entities;
using Newtonsoft.Json.Linq;

namespace twoCube.Services
{
    /// <summary>
    /// Summary description for MemberControllerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MemberControllerService : System.Web.Services.WebService
    {

        [WebMethod(Description = "Add User. String firstName, String lastName, String userName, Stirng password, int age, String location, String email, String qn, String answer")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void AddUser(string jsonString)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    JObject jsonObject = JObject.Parse(jsonString);   
                    var user = new Entities.Member
                    {
                        memberFirstName = jsonObject.SelectToken("firstName").ToString(),
                        memberLastName = jsonObject.SelectToken("lastName").ToString(),
                        userName = jsonObject.SelectToken("userName").ToString(),
                        memberPassword = jsonObject.SelectToken("password").ToString(),
                        dateOfBirthday = DateTime.Parse(jsonObject.SelectToken("dobCal").ToString()),
                        memberEmail = jsonObject.SelectToken("email").ToString()
                    };

                    session.Save(user);
                    transaction.Commit();
                    //print

                    JavaScriptSerializer js = new JavaScriptSerializer();
 
                    Context.Response.Write(js.Serialize(user));
                   
                }
            }
        }

        [WebMethod(Description = "View list of users. For create validation. only unique username can be created.")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void listOfUsers(string jsonString) //check username exist
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    JObject jsonObject = JObject.Parse(jsonString);   
                    var member = Member.GetByUserName(session, jsonObject.SelectToken("userName").ToString());
                    if (member == null)
                    {
                        Context.Response.Write(js.Serialize(new Response {userExists = 0}));
                    }
                    else {
                        Context.Response.Write(js.Serialize(new Response { userExists = 1 }));
                    }
                }
            }
        }

        public class Response
        {
            public int userExists { get; set; }
        }

        [WebMethod(Description = "Email validation. unique email can be created.")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void checkEmailExist(string jsonString)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    JObject jsonObject = JObject.Parse(jsonString);
                    var member = Member.GetByEmail(session, jsonObject.SelectToken("email").ToString());
                    if (member == null)
                    {
                        Context.Response.Write(js.Serialize(new Response1 { emailExists = 0 }));
                    }
                    else
                    {
                        Context.Response.Write(js.Serialize(new Response1 { emailExists = 1 }));
                    }
                }
            }
        }

        public class Response1
        {
            public int emailExists { get; set; }
        }

        [WebMethod(Description = "View User. Take in string username, string password")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void ViewUserDetails(string userName, string password)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    
                }
            }
        }

        [WebMethod(Description = "Update User, String firstName, String lastName, String userName, Stirng password, int age, String location, String email, String qn, String answer")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void UpdateUserDetails(string jsonString)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                { }
            }
        }

        [WebMethod(Description = "Update password, String userName, Stirng password")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void UpdateUserPassword(string jsonString)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                }
            }
        }

        [WebMethod(Description = "Login, string username, string password")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void Login(string jsonString)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                { }
            }
        }

    }
}
