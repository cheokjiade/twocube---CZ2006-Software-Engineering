using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.Entities
{
    public class SurveyQuestion
    {
        public virtual int Id { get; set; }
        public virtual int surveyQuestionType { get; set; }
        public virtual string surveyQuestionTitle { get; set; }
        public virtual IList<SurveyQuestionOption> surveyQuestionOptionList { get; set; }
        public SurveyQuestion() 
        {
            surveyQuestionOptionList = new List<SurveyQuestionOption>();
        }

        public virtual void AddSurvey(SurveyQuestionOption surveyQuestionOption)
        {
            surveyQuestionOptionList.Add(surveyQuestionOption);
        }
    }
}