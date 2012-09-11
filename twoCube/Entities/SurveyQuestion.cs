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
        public virtual bool surveyQuestionIsCompulsory { get; set; }
        public virtual string surveyQuestionTitle { get; set; }
        public virtual IList<SurveyQuestionOption> surveyQuestionOptionList { get; set; }
        public virtual IList<SurveyQuestionResponse> surveyQuestionResponseList { get; set; }

        
        public SurveyQuestion() 
        {
            surveyQuestionOptionList = new List<SurveyQuestionOption>();
            surveyQuestionResponseList = new List<SurveyQuestionResponse>();
        }

        public virtual void AddSurvey(SurveyQuestionOption surveyQuestionOption)
        {
            surveyQuestionOptionList.Add(surveyQuestionOption);
        }

        public virtual void AddSurveyQuestion(SurveyQuestionResponse surveyQuestionResponse)
        {
            surveyQuestionResponseList.Add(surveyQuestionResponse);
        }
    }
}