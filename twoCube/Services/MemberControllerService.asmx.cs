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

        [WebMethod(Description = "Add User. String firstName, String lastName, String userName, String password, String email")]
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
                        memberEmail = jsonObject.SelectToken("email").ToString()
                    };

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    DateTime dt = new DateTime();
                    user.memberHash = util.UtilityMethods.CalculateMD5Hash(user.userName + dt.ToShortTimeString());
                    Context.Response.Write(js.Serialize(new Response3 { LogIn = 1, twocubeSSO = user.memberHash }));
                    session.Save(user);
                    transaction.Commit();
                   
                }
            }
        }

        [WebMethod(Description = "Add User. String firstName, String lastName, String userName, String password, String email, String qn, String answer")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void AddFBUser(string jsonString)
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
                        memberEmail = jsonObject.SelectToken("email").ToString()
                    };

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    user.memberHash = util.UtilityMethods.CalculateMD5Hash(user.userName + DateTime.Now.ToShortTimeString());
                    Context.Response.Write(js.Serialize(new Response3 { LogIn = 1, twocubeSSO = user.memberHash }));
                    session.Save(user);
                    transaction.Commit();
                }
            }
        }

        [WebMethod(Description = "View list of users. For create validation. only unique username can be created.")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void listOfUsers(string jsonString)
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

        [WebMethod(Description = "View User. Take in string userhash")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void ViewUserDetails(string jsonString)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    JObject jsonObject = JObject.Parse(jsonString);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(Entities.Member.GetByHash(session, jsonObject.SelectToken("memberHash").ToString())));
                }
            }
        }

        [WebMethod(Description = "Update User. Take in string username, string password, string email")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void UpdateUserDetails(string jsonString)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    JObject jsonObject = JObject.Parse(jsonString);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var user = Entities.Member.GetByLogin(session, jsonObject.SelectToken("username").ToString(), jsonObject.SelectToken("password").ToString());
                    user.memberFirstName = jsonObject.SelectToken("firstName").ToString();
                    user.memberLastName = jsonObject.SelectToken("lastName").ToString();
                    user.memberEmail = jsonObject.SelectToken("email").ToString();
                    session.SaveOrUpdate(user);
                    transaction.Commit();

                }
            }
        }

        [WebMethod(Description = "Update password, String userName, String password")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void UpdateUserPassword(string jsonString)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    JObject jsonObject = JObject.Parse(jsonString);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var user = Entities.Member.GetByLogin(session, jsonObject.SelectToken("username").ToString(), jsonObject.SelectToken("password").ToString());
                    user.memberPassword = jsonObject.SelectToken("npassword").ToString();
                    session.SaveOrUpdate(user);
                    transaction.Commit();
                }
            }
        }

        [WebMethod(Description = "Validate cpassword")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void validatecpw(string jsonString)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    JObject jsonObject = JObject.Parse(jsonString);
                    var member = Entities.Member.GetByLogin(session, jsonObject.SelectToken("username").ToString(), jsonObject.SelectToken("password").ToString());
                    if (member == null)
                    {
                        Context.Response.Write(js.Serialize(new pwResponse { pwExists = 0 }));
                    }
                    else
                    {
                        Context.Response.Write(js.Serialize(new pwResponse { pwExists = 1 }));
                    }
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
                {
                    JObject jsonObject = JObject.Parse(jsonString);
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    var member = Member.GetByLogin(session, jsonObject.SelectToken("username").ToString(), jsonObject.SelectToken("password").ToString());
                    if (member == null)
                    {
                        Context.Response.Write(js.Serialize(new Response3 { LogIn = 0 }));
                    }
                    else
                    {
                        DateTime dt = new DateTime();
                        member.memberHash = util.UtilityMethods.CalculateMD5Hash(member.userName+dt.ToShortTimeString());
                        Context.Response.Write(js.Serialize(new Response3 { LogIn = 1, twocubeSSO = member.memberHash }));
                        session.SaveOrUpdate(member);
                        transaction.Commit();
                    }
                }
            }
        }

        [WebMethod(Description = "Login, string username, string password")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void FBLogin(string FBID, string firstName, string lastName, string email)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    //JObject jsonObject = JObject.Parse(jsonString);
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    var member = Member.GetByFBID(session, FBID);
                    if (member == null)
                    {
                        var user = new Entities.Member
                        {
                            memberFirstName = firstName,
                            memberLastName = lastName,
                            userName = FBID,
                            memberPassword = FBID,
                            memberEmail = email, 
                            memberFBID = FBID
                        };
                        user.memberHash = util.UtilityMethods.CalculateMD5Hash(user.userName + DateTime.Now.ToShortTimeString());
                        Context.Response.Write(js.Serialize(new Response3 { LogIn = 1, twocubeSSO = user.memberHash }));
                        session.Save(user);
                        transaction.Commit();
                        //Context.Response.Write(js.Serialize(new Response3 { LogIn = 0 }));
                    }
                    else
                    {
                        //DateTime dt = new DateTime();
                        member.memberHash = util.UtilityMethods.CalculateMD5Hash(member.userName + DateTime.Now.ToShortTimeString());
                        Context.Response.Write(js.Serialize(new Response3 { LogIn = 1, twocubeSSO = member.memberHash }));
                        session.SaveOrUpdate(member);
                        transaction.Commit();
                    }
                }
            }
        }
        
        public class Response1 //to check if email already existed.
        {
            public int emailExists { get; set; }
        }
        public class Response
        {
            public int userExists { get; set; }
        }
        public class pwResponse
        {
            public int pwExists { get; set; }
        }
        public class Response3
        {
            public int LogIn { get; set; }
            public string twocubeSSO { get; set; }
        }

    }
}
