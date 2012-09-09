using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.Entities
{
    public class Survey
    {
        public virtual int Id { get; set; }
        public virtual string surveyTitle { get; set; }
        public virtual string surveyDescription { get; set; }
        public virtual bool surveyStatus { get; set; }
        public virtual DateTime surveyCreated { get; set; }
        public virtual DateTime surveyStartDate { get; set; }
        public virtual DateTime surveyEndDate { get; set; }
        public virtual IList<SurveyQuestion> surveyQuestionList { get; set; }

        public Survey()
        {
            surveyQuestionList = new List<SurveyQuestion>();
            surveyCreated = DateTime.Now;
        }

        public virtual void AddSurveyQuestion(SurveyQuestion surveyQuestion)
        {
            surveyQuestionList.Add(surveyQuestion);
        }


    }
}