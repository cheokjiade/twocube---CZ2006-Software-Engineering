using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using twoCube.SurveyResultsEntities;
using System.Web.Script.Serialization;
using twoCube.Entities;

namespace twoCube.Services
{
    /// <summary>
    /// Summary description for surveyResults
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class surveyResults : System.Web.Services.WebService
    {
        [WebMethod]
        //public void getSurvey(int surveyID)
        public void getSurvey(int id, string userhash)
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var member = Member.GetByHash(session,userhash);
                    if (member == null)
                        return;
                    var survey = member.memberSurveyList.ToList<Survey>().Find(item => item.Id == id);
                    //var survey = Entities.Survey.GetById(session, id);
                    var result = new SurveyResults();
                    result.surveyTitle = survey.surveyTitle;
                    result.noOfRespondents = survey.respondentList.Count;
                    int i = 0;
                    int totalTime = 0;
                    foreach (var respondent in survey.respondentList)
                    {
                        totalTime += respondent.respondentTime;
                    }
                    result.avgTime = (totalTime / result.noOfRespondents)/1000;

                    foreach (var question in survey.surveyQuestionList)
                    {
                        var resultQn = new Questions();
                        i++;
                        resultQn.questionTitle = question.surveyQuestionTitle;
                        resultQn.questionType = question.surveyQuestionType;
                        switch (question.surveyQuestionType)
                        {
                            //multiple choices and checkboxes
                            case 0:
                            case 1:
                            case 5:
                                int count = 0;
                                foreach (var option in question.surveyQuestionOptionList)
                                {
                                    var questionOption = new Options();
                                    questionOption.optionTitle = option.surveyQuestionOptionTitle;
                                    foreach (var response in question.surveyQuestionResponseList)
                                    {
                                        if (response.responseIntegerValue == count)
                                        {
                                            questionOption.noOfRespondents++;
                                        }
                                    }
                                    count++;
                                    resultQn.optionList.Add(questionOption);

                                }

                                result.questionList.Add(resultQn);
                                break;

                            case 2: //slider
                            case 3: //numerical input
                                {
                                    foreach (var response in question.surveyQuestionResponseList)
                                    {
                                        var questionOption = new Options { responseStr = response.responseIntegerValue.ToString() , noOfRespondents=1};
                                        bool add = true;
                                        foreach(var tempOption in resultQn.optionList)
                                        {
                                            if (tempOption.responseStr.Equals(questionOption.responseStr))
                                            {
                                                tempOption.noOfRespondents++;
                                                add = false;
                                            }
                                        }
                                        if(add)
                                        resultQn.optionList.Add(questionOption);

                                    }
                                    result.questionList.Add(resultQn);
                                    break;
                                }
                            case 4: //date
                                foreach (var response in question.surveyQuestionResponseList)
                                {
                                    var questionOption = new Options {responseStr = response.responseStringValue, noOfRespondents=1};
                                    bool add = true;
                                        foreach(var tempOption in resultQn.optionList)
                                        {
                                            if (tempOption.responseStr.Equals(questionOption.responseStr))
                                            {
                                                tempOption.noOfRespondents++;
                                                add = false;
                                            }
                                        }
                                        if(add)
                                        resultQn.optionList.Add(questionOption);

                                    }
                                    result.questionList.Add(resultQn);
                                    break;
                        }
                        
                    }

                    //print to webservice
                    
                    Context.Response.Write(js.Serialize(result));
                }
            }
        }

        [WebMethod(Description = "takes in a jsonobject containing the completed survey done by respondent")]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void createCSV1(int id, string userhash)
        {
            System.Web.HttpResponse csvresponse = System.Web.HttpContext.Current.Response;
            csvresponse.Clear();
            csvresponse.AddHeader("content-disposition", "attachment; filename=surveyResults.csv");
            csvresponse.ContentType = "text/csv";
            csvresponse.Write("Question No: ,Question: ,Option: ,Responses: ,No of Responses: ,");
            csvresponse.Write(Environment.NewLine);

            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Entities.Survey survey;
                    //getSurvey(id, userhash);
                    survey = Entities.Survey.GetById(session, id);
                    int i = 0;
                    foreach (var question in survey.surveyQuestionList)
                    {
                        switch (question.surveyQuestionType)
                        {
                            case 0:
                            case 1:
                            case 5:
                                {
                                    int optionNo = 0;
                                    foreach (var option in question.surveyQuestionOptionList)
                                    {
                                        string fileRow = "";
                                        string cell = "";
                                        cell += "Question " + (i + 1).ToString() + ",";
                                        if (question.surveyQuestionTitle.Contains(","))
                                        {
                                            cell += "\"" + question.surveyQuestionTitle + "\"" + ",";
                                        }
                                        else
                                        {
                                            cell += question.surveyQuestionTitle + ",";
                                        }
                                        if (option.surveyQuestionOptionTitle.Contains(","))
                                        {
                                            cell += "\"" + option.surveyQuestionOptionTitle + "\"" + ",";
                                        }
                                        else
                                        {
                                            cell += option.surveyQuestionOptionTitle + ",";
                                        }

                                        cell += "N.A" + ",";
                                        int choices = 0;
                                        foreach (var response in question.surveyQuestionResponseList)
                                        {
                                            if (response.responseIntegerValue == optionNo)
                                            {
                                                choices++;
                                            }
                                        }
                                        optionNo++;
                                        cell += choices + ",";
                                        fileRow += cell + ",";
                                        csvresponse.Write(fileRow);
                                        csvresponse.Write(Environment.NewLine);
                                    }
                                    i++;
                                    break;
                                }

                            case 2:
                            case 3:
                            case 4:
                                {
                                    foreach (var option in question.surveyQuestionOptionList)
                                    {
                                        foreach (var response in question.surveyQuestionResponseList)
                                        {
                                            string fileRow = "";
                                            string cell = "";
                                            cell += "Question " + (i + 1).ToString() + ",";
                                            if (question.surveyQuestionTitle.Contains(","))
                                            {
                                                cell += "\"" + question.surveyQuestionTitle + "\"" + ",";
                                            }
                                            else
                                            {
                                                cell += question.surveyQuestionTitle + ",";
                                            }
                                            cell += "N.A" + ",";
                                            if (response.responseStringValue.Contains(","))
                                            {
                                                cell += "\"" + response.responseStringValue + "\"" + ",";
                                            }
                                            else
                                            {
                                                cell += response.responseStringValue + ",";
                                            }
                                            cell += "1" + ",";
                                            fileRow += cell + ",";
                                            csvresponse.Write(fileRow);
                                            csvresponse.Write(Environment.NewLine);

                                        }

                                    }
                                    i++;
                                    break;
                                }
                        }
                    }

                }
            }
            csvresponse.End();
        }
        
        public string responseStr { get; set; }
    }
}
