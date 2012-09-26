﻿using System;
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

        [WebMethod(Description = "takes in a jsonobject containing the completed survey done by respondent")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void repeater(string formString, string elementString)
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
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 3 };
                                    surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "" });
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "radio":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 0 };
                                    foreach (var option in question.SelectToken("options").ToList())
                                    {
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = option.SelectToken("option").ToString() });
                                    }
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "checkbox":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 1 };
                                    foreach (var option in question.SelectToken("options").ToList())
                                    {
                                        surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = option.SelectToken("option").ToString() });
                                    }
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                            case "date":
                                {
                                    var surveyQuestion = new Entities.SurveyQuestion { surveyQuestionTitle = question.SelectToken("title").ToString(), surveyQuestionType = 4 };
                                    surveyQuestion.surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "" });
                                    survey.surveyQuestionList.Add(surveyQuestion);
                                    break;
                                }
                        }
                    }
                    var member = Member.GetById(session,1);
                    member.AddSurvey(survey);
                    session.SaveOrUpdate(member);
                    transaction.Commit();
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

                            var respondent = new Entities.Respondent { respondentIPAddress = ipAddress, respondentSessionID = "fromworkingresponse" };
                            jsonObject = JObject.Parse(jToken.ToString());
                            int i = 0;
                            foreach (var question in survey.surveyQuestionList)
                            {
                                if (jsonObject.TryGetValue(i.ToString(), out jToken))
                                {
                                    switch (question.surveyQuestionType)
                                    {
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
    }
}
                            