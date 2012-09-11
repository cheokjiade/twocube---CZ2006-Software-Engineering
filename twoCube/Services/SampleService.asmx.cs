﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using twoCube.Entities;

namespace twoCube.Services
{
    /// <summary>
    /// Summary description for SampleService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SampleService : System.Web.Services.WebService
    {

        [WebMethod(Description = "Your Description")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void Insert()
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var user = new Entities.User { userName = "username1", userPassword = "password" };
                    
                    var survey = new Entities.Survey { surveyDescription = "A Random Sample Survey. This is just a sample of how json can be used to render a survey.", surveyTitle = "Sample Survey", surveyQuestionList = new List<Entities.SurveyQuestion>() };
                    survey.surveyQuestionList.Add(new Entities.SurveyQuestion { surveyQuestionTitle = "What is your favourite color?", surveyQuestionType = 1, surveyQuestionOptionList = new List<Entities.SurveyQuestionOption>() });
                    survey.surveyQuestionList.ElementAt(0).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "White" });
                    survey.surveyQuestionList.ElementAt(0).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Yellow" });
                    survey.surveyQuestionList.ElementAt(0).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Blue" });
                    survey.surveyQuestionList.ElementAt(0).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Green" });
                    survey.surveyQuestionList.ElementAt(0).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Enter another color:", surveyQuestionOptionType = 2 });
                    survey.surveyQuestionList.Add(new Entities.SurveyQuestion { surveyQuestionTitle = "Who is the most hardworking person in our team?", surveyQuestionType = 1, surveyQuestionOptionList = new List<Entities.SurveyQuestionOption>() });
                    survey.surveyQuestionList.ElementAt(1).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
                    survey.surveyQuestionList.ElementAt(1).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Wei Leng" });
                    survey.surveyQuestionList.ElementAt(1).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Hong Jing" });
                    survey.surveyQuestionList.ElementAt(1).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Xu Ai" });
                    survey.surveyQuestionList.ElementAt(1).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Wesley" });
                    survey.surveyQuestionList.Add(new Entities.SurveyQuestion { surveyQuestionTitle = "And the best phone is", surveyQuestionType = 1, surveyQuestionOptionList = new List<Entities.SurveyQuestionOption>() });
                    survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Galaxy S 3" });
                    survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Galaxy S 2" });
                    survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Galaxy S" });
                    survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "HTC One X" });
                    survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Galaxy Nexus" });
                    survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Motorola Droid Razr Maxx" });
                    survey.surveyQuestionList.Add(new Entities.SurveyQuestion { surveyQuestionTitle = "Who is the most hardworking person in our team? (You can choose more than 1 answer)", surveyQuestionType = 2, surveyQuestionOptionList = new List<Entities.SurveyQuestionOption>() });
                    survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
                    survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
                    survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
                    survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
                    survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
                    survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
                    survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
                    survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
                    survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
                    survey.surveyQuestionList.Add(new Entities.SurveyQuestion { surveyQuestionTitle = "How hardworking is June?", surveyQuestionType = 3, surveyQuestionOptionList = new List<Entities.SurveyQuestionOption>() });
                    survey.surveyQuestionList.ElementAt(4).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "Hardworkingness" });
                    survey.surveyQuestionList.Add(new Entities.SurveyQuestion { surveyQuestionTitle = "How young is this pretty young star? Numeric input.", surveyQuestionType = 4, surveyQuestionOptionList = new List<Entities.SurveyQuestionOption>() });
                    survey.surveyQuestionList.ElementAt(5).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/weileng.peh/picture?type=large" });
                    survey.surveyQuestionList.Add(new Entities.SurveyQuestion { surveyQuestionTitle = "Or the birthday of this talented actor/singer? Date input.", surveyQuestionType = 5, surveyQuestionOptionList = new List<Entities.SurveyQuestionOption>() });
                    survey.surveyQuestionList.ElementAt(6).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/197371292379/picture?type=large" });
                    survey.surveyQuestionList.Add(new Entities.SurveyQuestion { surveyQuestionTitle = "Which picture is the odd one out?", surveyQuestionType = 6, surveyQuestionOptionList = new List<Entities.SurveyQuestionOption>() });
                    survey.surveyQuestionList.ElementAt(7).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/alexei.sourin/picture?type=square" });
                    survey.surveyQuestionList.ElementAt(7).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/kuiyu.chang/picture?type=square" });
                    survey.surveyQuestionList.ElementAt(7).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/bengkoon.ng/picture?type=square" });
                    survey.surveyQuestionList.ElementAt(7).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/bingsheng.he/picture?type=square" });
                    survey.surveyQuestionList.ElementAt(7).surveyQuestionOptionList.Add(new Entities.SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/limws.brandon/picture?type=square" });
                    user.AddSurvey(survey);
                    session.SaveOrUpdate(user);
                    transaction.Commit();

                }

            }
            //Context.Response.Write(js.Serialize(survey));
        }

        [WebMethod(Description = "Your Description")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void Select()
        {
            
                using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
                {
                    // retreive all stores and display them
                    using (session.BeginTransaction())
                    {
                        var users = session.CreateCriteria(typeof(Entities.User))
                            .List<Entities.User>();
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        foreach (var store in users)
                        {
                            Context.Response.Write(js.Serialize(store));
                        }
                    }
                }
            
        }

        [WebMethod(Description = "Your Description")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void SampleSurvey()
        {
            // Return JSON data
            var survey = new Survey { surveyDescription = "A Random Sample Survey. This is just a sample of how json can be used to render a survey.", surveyTitle = "Sample Survey", surveyQuestionList = new List<SurveyQuestion>() };
            survey.surveyQuestionList.Add(new SurveyQuestion { surveyQuestionTitle = "What is your favourite color?", surveyQuestionType = 1, surveyQuestionOptionList = new List<SurveyQuestionOption>() });
            survey.surveyQuestionList.ElementAt(0).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "White" });
            survey.surveyQuestionList.ElementAt(0).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Yellow" });
            survey.surveyQuestionList.ElementAt(0).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Blue" });
            survey.surveyQuestionList.ElementAt(0).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Green" });
            survey.surveyQuestionList.ElementAt(0).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Enter another color:", surveyQuestionOptionType = 2 });
            survey.surveyQuestionList.Add(new SurveyQuestion { surveyQuestionTitle = "Who is the most hardworking person in our team?", surveyQuestionType = 1, surveyQuestionOptionList = new List<SurveyQuestionOption>() });
            survey.surveyQuestionList.ElementAt(1).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
            survey.surveyQuestionList.ElementAt(1).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Wei Leng" });
            survey.surveyQuestionList.ElementAt(1).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Hong Jing" });
            survey.surveyQuestionList.ElementAt(1).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Xu Ai" });
            survey.surveyQuestionList.ElementAt(1).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Wesley" });
            survey.surveyQuestionList.Add(new SurveyQuestion { surveyQuestionTitle = "And the best phone is", surveyQuestionType = 1, surveyQuestionOptionList = new List<SurveyQuestionOption>() });
            survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Galaxy S 3" });
            survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Galaxy S 2" });
            survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Galaxy S" });
            survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "HTC One X" });
            survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Galaxy Nexus" });
            survey.surveyQuestionList.ElementAt(2).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Motorola Droid Razr Maxx" });
            survey.surveyQuestionList.Add(new SurveyQuestion { surveyQuestionTitle = "Who is the most hardworking person in our team? (You can choose more than 1 answer)", surveyQuestionType = 2, surveyQuestionOptionList = new List<SurveyQuestionOption>() });
            survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
            survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
            survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
            survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
            survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
            survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
            survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
            survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
            survey.surveyQuestionList.ElementAt(3).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "June" });
            survey.surveyQuestionList.Add(new SurveyQuestion { surveyQuestionTitle = "How hardworking is June?", surveyQuestionType = 3, surveyQuestionOptionList = new List<SurveyQuestionOption>() });
            survey.surveyQuestionList.ElementAt(4).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "Hardworkingness" });
            survey.surveyQuestionList.Add(new SurveyQuestion { surveyQuestionTitle = "How young is this pretty young star? Numeric input.", surveyQuestionType = 4, surveyQuestionOptionList = new List<SurveyQuestionOption>() });
            survey.surveyQuestionList.ElementAt(5).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/weileng.peh/picture?type=large" });
            survey.surveyQuestionList.Add(new SurveyQuestion { surveyQuestionTitle = "Or the birthday of this talented actor/singer? Date input.", surveyQuestionType = 5, surveyQuestionOptionList = new List<SurveyQuestionOption>() });
            survey.surveyQuestionList.ElementAt(6).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/197371292379/picture?type=large" });
            survey.surveyQuestionList.Add(new SurveyQuestion { surveyQuestionTitle = "Which picture is the odd one out?", surveyQuestionType = 6, surveyQuestionOptionList = new List<SurveyQuestionOption>() });
            survey.surveyQuestionList.ElementAt(7).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/alexei.sourin/picture?type=square" });
            survey.surveyQuestionList.ElementAt(7).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/kuiyu.chang/picture?type=square" });
            survey.surveyQuestionList.ElementAt(7).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/bengkoon.ng/picture?type=square" });
            survey.surveyQuestionList.ElementAt(7).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/bingsheng.he/picture?type=square" });
            survey.surveyQuestionList.ElementAt(7).surveyQuestionOptionList.Add(new SurveyQuestionOption { surveyQuestionOptionTitle = "http://graph.facebook.com/limws.brandon/picture?type=square" });
            JavaScriptSerializer js = new JavaScriptSerializer();
            //string retJSON = js.Serialize(e);
            //return retJSON;
            Context.Response.Write(js.Serialize(survey));

        }
    }

    public class Survey
    {
        public string surveyTitle;
        public string surveyDescription;
        public List<SurveyQuestion> surveyQuestionList;
    }
    public class SurveyQuestion
    {
        public string surveyQuestionTitle;
        public int surveyQuestionType;
        public List<SurveyQuestionOption> surveyQuestionOptionList;
    }
    public class SurveyQuestionOption
    {
        public string surveyQuestionOptionTitle;
        public int surveyQuestionOptionType;
        public string surveyQuestionOptionRange;
    }
}