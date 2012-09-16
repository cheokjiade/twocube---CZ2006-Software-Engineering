using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using Newtonsoft.Json.Linq;

namespace twoCube.Services
{
    /// <summary>
    /// Summary description for SurveyControllerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SurveyControllerService : System.Web.Services.WebService
    {

        [WebMethod(Description = "Your Description")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getSurveyById(int Id)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                //string retJSON = js.Serialize(e);
                //return retJSON;
                var survey = Entities.Survey.GetById(session, Id);
                survey.respondentList = null;
                foreach(var question in survey.surveyQuestionList)
                {
                    question.surveyQuestionResponseList = null;
                }
                Context.Response.Write(js.Serialize(survey));

            }
        }

        [WebMethod(Description = "Your Description")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void repeater(string jsonString)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var foo = js.Deserialize<Dictionary<string, object>>(jsonString);
                dynamic json = JValue.Parse(jsonString);
                JObject jsonObject = JObject.Parse(jsonString);

                string a = "";
                foreach (var item in jsonObject)
                {
                    a+= item.Value;
                }
                //string retJSON = js.Serialize(e);
                //return retJSON;
                //if(foo.TryGetValue("surveyId",out))
                Context.Response.Write(a);

            }
        }
    }

    
}
