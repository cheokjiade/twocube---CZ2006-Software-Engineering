using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using Newtonsoft.Json.Linq;
using twoCube.Entities;

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
        public void getSurveyList(string memberHash)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var member = Entities.Member.GetByHash(session, memberHash);
                List<Survey> surveyList = member.memberSurveyList.ToList();
                List<SurveyResponse> surveyResponseList = new List<SurveyResponse>();
                foreach (var survey in surveyList)
                {
                    surveyResponseList.Add(new SurveyResponse {Id = survey.Id, surveyName = survey.surveyTitle, surveyStatus = survey.surveyStatus });
                }
                //survey.respondentList = null;
                //foreach (var question in survey.surveyQuestionList)
                //{
                //    question.surveyQuestionResponseList = null;
                //}
                Context.Response.Write(js.Serialize(surveyResponseList));

            }
        }

        [WebMethod(Description = "Your Description")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void closeSurvey(string memberHash, int surveyID)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var survey = Entities.Survey.GetById(session, surveyID);
                    survey.surveyStatus = false;
                    session.SaveOrUpdate(survey);
                    transaction.Commit();
                }
                
                //survey.respondentList = null;
                //foreach (var question in survey.surveyQuestionList)
                //{
                //    question.surveyQuestionResponseList = null;
                //}
                //Context.Response.Write(js.Serialize(surveyResponseList));

            }
        }

        [WebMethod(Description = "takes in a jsonobject containing the completed survey done by respondent")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void repeater(string formString, string elementString, string memberHash)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    JObject jsonObject = JObject.Parse(formString);
                    var survey = new Entities.Survey { surveyTitle = jsonObject.SelectToken("name").ToString(), surveyDescription = jsonObject.SelectToken("description").ToString() };
                    JToken jToken;
                    jsonObject = JObject.Parse(elementString);
                    var questionList = jsonObject.SelectToken("elements").ToList();
                    foreach (var question in questionList)
                    {
                        switch (question.SelectToken("type").ToString())
                        {
                            case "number":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 3, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "" });
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "radio":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 0, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    foreach (var option in question.SelectToken("options").ToList())
                                    {
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = option.SelectToken("option").ToString() });
                                    }
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "checkbox":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 1, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    foreach (var option in question.SelectToken("options").ToList())
                                    {
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = option.SelectToken("option").ToString() });
                                    }
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "date":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 4, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "" });
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "slider":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 2, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "", surveyQuestionOptionMaxText = question.SelectToken("size_max") != null ? question.SelectToken("size_max").ToString() : "Max", surveyQuestionOptionMinText = question.SelectToken("size_min") !=null? question.SelectToken("size_min").ToString() : "Min" });
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "scaler":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 5, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    int size = Int32.Parse(question.SelectToken("scaleAmount").ToString());
                                    for (int i = 0; i < size; i++)
                                    {
                                        if (i == 0) surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("mintext")!=null?question.SelectToken("mintext").ToString():"Worst" });
                                        else if (i == (size - 1)) surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("maxtext")!=null?question.SelectToken("maxtext").ToString():"Best" });
                                        else surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "" });
                                    }
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                        break;
                                }

                            case "text":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 6, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "" });
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }

                            case "textarea":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 7, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "" });
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "signature":
                                {

                                    break;
                                }
                            case "photo":
                                {

                                    break;
                                }
                            case "section":
                                {

                                    break;
                                }
                            case "img_checkbox":
                                {

                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 1, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    if (question.SelectToken("satisfactory_vUnsatisfactory")!=null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("satisfactory_vUnsatisfactory").ToString(), surveyQuestionOptionTitleType = 2 });
                                    if (question.SelectToken("satisfactory_Unsatisfactory") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("satisfactory_Unsatisfactory").ToString(), surveyQuestionOptionTitleType = 2 });
                                    if (question.SelectToken("satisfactory_Neutral") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("satisfactory_Neutral").ToString(), surveyQuestionOptionTitleType = 2 });
                                    if (question.SelectToken("satisfactory_Satisfactory")!=null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("satisfactory_Satisfactory").ToString(), surveyQuestionOptionTitleType = 2 });
                                    if (question.SelectToken("satisfactory_vSatisfactory")!=null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("satisfactory_vSatisfactory").ToString(), surveyQuestionOptionTitleType = 2 });
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "satisfactory":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 5, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    if (question.SelectToken("satisfactory_vUnsatisfactory") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("satisfactory_vUnsatisfactory").ToString(), surveyQuestionOptionTitleType = question.SelectToken("satisfactory_vUnsatisfactory").ToString().Contains("http://") ?  2 :  1 });
                                    if (question.SelectToken("satisfactory_Unsatisfactory") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("satisfactory_Unsatisfactory").ToString(), surveyQuestionOptionTitleType = question.SelectToken("satisfactory_vUnsatisfactory").ToString().Contains("http://") ? 2 : 1 });
                                    if (question.SelectToken("satisfactory_Neutral") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("satisfactory_Neutral").ToString(), surveyQuestionOptionTitleType = question.SelectToken("satisfactory_vUnsatisfactory").ToString().Contains("http://") ? 2 : 1 });
                                    if (question.SelectToken("satisfactory_Satisfactory") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("satisfactory_Satisfactory").ToString(), surveyQuestionOptionTitleType = question.SelectToken("satisfactory_vUnsatisfactory").ToString().Contains("http://") ? 2 : 1 });
                                    if (question.SelectToken("satisfactory_vSatisfactory") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("satisfactory_vSatisfactory").ToString(), surveyQuestionOptionTitleType = question.SelectToken("satisfactory_vUnsatisfactory").ToString().Contains("http://") ? 2 : 1 });
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "img_radio":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 0, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    if (question.SelectToken("img_radio_vUnsatisfactory") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("img_radio_vUnsatisfactory").ToString(), surveyQuestionOptionTitleType = 2 });
                                    if (question.SelectToken("img_radio_Unsatisfactory") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("img_radio_Unsatisfactory").ToString(), surveyQuestionOptionTitleType = 2 });
                                    if (question.SelectToken("img_radio_Neutral") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("img_radio_Neutral").ToString(), surveyQuestionOptionTitleType = 2 });
                                    if (question.SelectToken("img_radio_Satisfactory") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("img_radio_Satisfactory").ToString(), surveyQuestionOptionTitleType = 2 });
                                    if (question.SelectToken("img_radio_vSatisfactory") != null)
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = question.SelectToken("img_radio_vSatisfactory").ToString(), surveyQuestionOptionTitleType = 2 });
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "select":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 10, surveyQuestionIsCompulsory = question.SelectToken("title").ToString() == "1" };
                                    foreach (var option in question.SelectToken("options").ToList())
                                    {
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = option.SelectToken("option").ToString() });
                                    }
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                        
                        }
                    }
                    //var member = Member.GetById(session,1);
                    var member = Member.GetByHash(session, memberHash);
                    member.AddSurvey(survey);
                    session.SaveOrUpdate(member);
                    transaction.Commit();
                    HttpContext.Current.Response.Redirect("./../../viewsurveylist.htm");
                }

            }

        }

        [WebMethod(Description = "takes in a jsonobject containing the completed survey done by respondent")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void submitSurvey(string jsonString)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var foo = js.Deserialize<Dictionary<string, object>>(jsonString);
                    dynamic json = JValue.Parse(jsonString);
                    JObject jsonObject = JObject.Parse(jsonString);
                    JToken jToken;
                    Entities.Survey survey;
                    if (jsonObject.TryGetValue("surveyId", out jToken))
                    {
                        int surveyID = Int32.Parse(jToken.ToString());
                        survey = Entities.Survey.GetById(session, surveyID);
                        //Context.Response.Write(jToken);
                        if (jsonObject.TryGetValue("s", out jToken))
                        {
                            string ipAddress;
                            if (!String.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"]))
                                ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
                            else if (!String.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
                                ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                            else ipAddress = System.Web.HttpContext.Current.Request.UserHostAddress;
                            JToken time;
                            jsonObject.TryGetValue("surveyTime", out time);
                            int timeTaken = Int32.Parse(time.ToString());

                            var respondent = new Entities.Respondent { respondentIPAddress = ipAddress, respondentSessionID = "fromworkingresponse", respondentTime = timeTaken, respondentCountryCode = jsonObject.SelectToken("surveyLocationCountryCode").ToString(), respondentBrowser = jsonObject.SelectToken("surveyBrowserBrowser").ToString(), respondentOS = jsonObject.SelectToken("surveyBrowserOS").ToString(), respondentLang = jsonObject.SelectToken("surveyLocaleLang").ToString() };
                            jsonObject = JObject.Parse(jToken.ToString());
                            int i = 0;
                            foreach (var question in survey.surveyQuestionList)
                            {
                                if (jsonObject.TryGetValue(i.ToString(), out jToken))
                                {
                                    switch (question.surveyQuestionType)
                                    {
                                        case 10:
                                        case 0:
                                        case 5:
                                        case 2:
                                        case 3:
                                            {
                                                var response = new Entities.SurveyQuestionResponse { responseIsAnswered = true, responseType = 1, responseIntegerValue = Int32.Parse(jToken.ToString()) };
                                                respondent.surveyQuestionResponseList.Add(response);
                                                question.surveyQuestionResponseList.Add(response);
                                                break;
                                            }
                                        case 1:
                                            {
                                                var checkboxresults = jToken.ToList();
                                                foreach (var result in checkboxresults)
                                                {
                                                    var response = new Entities.SurveyQuestionResponse { responseIsAnswered = true, responseType = 1, responseIntegerValue = Int32.Parse(result.ToString()) };
                                                    respondent.surveyQuestionResponseList.Add(response);
                                                    question.surveyQuestionResponseList.Add(response);
                                                    Context.Response.Write(result);
                                                }

                                                break;
                                            }
                                        case 6:
                                        case 7:
                                        case 4:
                                            {
                                                var response = new Entities.SurveyQuestionResponse { responseIsAnswered = true, responseType = 2, responseStringValue = jToken.ToString() };
                                                respondent.surveyQuestionResponseList.Add(response);
                                                question.surveyQuestionResponseList.Add(response);
                                                break;
                                            }
                                    }
                                    Context.Response.Write(question.surveyQuestionTitle);

                                }
                                i++;
                            }
                            survey.AddRespondent(respondent);
                            session.SaveOrUpdate(survey);
                            transaction.Commit();
                        }
                    }
                }
            }
        }
        public class SurveyResponse
        {
            public int Id { get; set; }
            public string surveyName { get; set; }
            public bool surveyStatus { get; set; }
        }
    }
}
                            