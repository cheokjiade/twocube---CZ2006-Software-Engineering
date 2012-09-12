﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string userName { get; set; }
        public virtual string userPassword { get; set; }
        public virtual int userAge { get; set; }
        public virtual string userLocation { get; set; }
        public virtual string userEmail { get; set; }
        public virtual string userQuestion { get; set; }
        public virtual string userAnswer { get; set; }
        public virtual IList<Survey> userSurveys { get; set; }

        public User() 
        {
            userSurveys = new List<Survey>();
        }

        public virtual void AddSurvey(Survey survey)
        {
            userSurveys.Add(survey);
        }
    }
}