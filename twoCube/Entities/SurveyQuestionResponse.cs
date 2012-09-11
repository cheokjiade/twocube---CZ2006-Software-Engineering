using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.Entities
{
    public class SurveyQuestionResponse
    {
        public virtual int Id { get; set; }
        public virtual bool responseIsAnswered { get; set; }
        public virtual int responseType { get; set; }
        public virtual int responseIntegerValue { get; set; }
        public virtual string responseStringValue { get; set; }
    }
}