﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.Entities
{
    public class Respondent
    {
        public virtual int Id { get; set; }
        public virtual string respondentIPAddress { get; set; }
        public virtual string respondentSessionID { get; set; }
        public virtual IList<SurveyQuestionResponse> surveyQuestionResponseList { get; set; }

        public Respondent()
        {
            surveyQuestionResponseList = new List<SurveyQuestionResponse>();
        }

        public virtual void AddSurveyQuestion(SurveyQuestionResponse surveyQuestionResponse)
        {
            surveyQuestionResponseList.Add(surveyQuestionResponse);
        }
    }
}