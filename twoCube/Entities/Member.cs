using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.Entities
{
    public class Member
    {
        public virtual int Id { get; set; }
        public virtual string memberFirstName { get; set; } //Full name: Eg: Hello, June!
        public virtual string memberLastName { get; set; }
        public virtual string userName { get; set; } //Login name
        public virtual string memberPassword { get; set; }
        public virtual int memberAge { get; set; } //FB retrieve. If system registration then auto calculated with DOB given
        public virtual DateTime dateOfBirthday { get; set; }
        public virtual string memberLocation { get; set; }
        public virtual string memberEmail { get; set; }
        public virtual string memberQuestion { get; set; } //Forget password
        public virtual string memberAnswer { get; set; } //Forget password
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