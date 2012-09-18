using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using twoCube.SurveyResultsEntities;
using System.Web.Script.Serialization;

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
        public void getSurvey()
        {
            using (var session = FluentNHibernateConfiguration.InitFactory.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var survey = Entities.Survey.GetById(session, 2);
                    var result = new SurveyResults();

                    int i = 0;

                    foreach (var question in survey.surveyQuestionList)
                    {
                        var resultQn = new Questions();
                        i++;

                        int count = 0;
                        foreach (var option in question.surveyQuestionOptionList)
                        {
                            var questionOption = new Options();

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
                    }

                    //print to webservice
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }
            }
        }
    }
}
