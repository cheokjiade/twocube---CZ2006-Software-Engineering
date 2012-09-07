using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.Entities
{
    public class Survey
    {
        public virtual int Id { get; set; }
        public virtual string surveyName { get; set; }
        public virtual string surveyTitle { get; set; }
        public virtual bool surveyStatus { get; set; }
        public virtual DateTime surveyCreated { get; set; }
        public virtual DateTime surveyStartDate { get; set; }
        public virtual DateTime surveyEndDate { get; set; }
        public virtual IList<SurveyQuestion> surveyQuestions { get; set; }

        public Survey()
        {
            surveyQuestions = new List<SurveyQuestion>();
        }

        public virtual void AddSurveyQuestion(SurveyQuestion surveyQuestion)
        {
            surveyQuestions.Add(surveyQuestion);
        }


    }
}