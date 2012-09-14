using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.Entities
{
    public class Member
    {
        public virtual int Id { get; set; }
        public virtual string memberName { get; set; }
        public virtual string memberPassword { get; set; }
        public virtual int memberAge { get; set; }
        public virtual string memberLocation { get; set; }
        public virtual string memberEmail { get; set; }
        public virtual string memberQuestion { get; set; }
        public virtual string memberAnswer { get; set; }
        public virtual IList<Survey> memberSurveyList { get; set; }

        public Member() 
        {
            memberSurveyList = new List<Survey>();
        }

        public virtual void AddSurvey(Survey survey)
        {
            memberSurveyList.Add(survey);
        }
    }
}