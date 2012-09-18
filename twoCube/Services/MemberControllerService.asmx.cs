using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.IO;
using twoCube.Entities;

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

        [WebMethod(Description = "Add User")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void AddUser(int id, string firstName, string lastName, string userName, string password, int age, string loc, string email, 
            string qn, string ans)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var user = new Entities.Member { Id = id, memberFirstName= firstName, memberLastName= lastName, userName = userName, 
                    memberPassword = password, memberAge = age, memberLocation = loc, memberEmail = email, memberQuestion = qn, 
                    memberAnswer = ans};

                    session.Save(user);
                    transaction.Commit();
                    //print
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(user));
                }
            }
        }

    }
}
