using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.Entities
{
    public class Respondent
    {
        public virtual int Id { get; set; }
        public virtual int respondentTime { get; set; }
        public virtual DateTime respondentDateTime { get; set; }
        public virtual string respondentCountryCode { get; set; }
        public virtual string respondentBrowser { get; set; }
        public virtual string respondentOS { get; set; }
        public virtual string respondentLang { get; set; }
        public virtual string respondentIPAddress { get; set; }
        public virtual string respondentSessionID { get; set; }
        public virtual IList<SurveyQuestionResponse> surveyQuestionResponseList { get; set; }

        public Respondent()
        {
            surveyQuestionResponseList = new List<SurveyQuestionResponse>();
            respondentDateTime = DateTime.Now;
        }

        public virtual void AddSurveyQuestion(SurveyQuestionResponse surveyQuestionResponse)
        {
            surveyQuestionResponseList.Add(surveyQuestionResponse);
        }
    }
}