using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.Entities
{
    public class SurveyQuestionOption
    {
        public virtual int Id { get; set; }
        public virtual int surveyQuestionOptionType { get; set; }
        public virtual string surveyQuestionOptionTitle { get; set; }
        public virtual int surveyQuestionOptionTitleType { get; set; }
        public virtual int surveyQuestionOptionRange{ get; set; }
    }
}