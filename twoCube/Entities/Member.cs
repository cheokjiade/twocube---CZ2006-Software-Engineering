﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

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
        public virtual string memberHash { get; set; }
        public virtual string memberFBID { get; set; }
        public virtual IList<Survey> memberSurveyList { get; set; }

        public Member() 
        {
            memberSurveyList = new List<Survey>();
        }

        public virtual void AddSurvey(Survey survey)
        {
            memberSurveyList.Add(survey);
        }
        public static Member GetById(ISession session, int id)
        {
            return session.CreateCriteria(typeof(Member))
                .Add(Expression.Eq("Id", id))
                .UniqueResult<Member>();
        }
        public static Member GetByLogin(ISession session, string username, string password)
        {
            return session.CreateCriteria(typeof(Member))
                .Add(Expression.Eq("userName", username))
                .Add(Expression.Eq("memberPassword", password))
                .UniqueResult<Member>();
        }
        public static Member GetByUserName(ISession session, string userName)
        {
            return session.CreateCriteria(typeof(Member))
                .Add(Expression.Eq("userName", userName))
                .UniqueResult<Member>();
        }
        public static Member GetByEmail(ISession session, string memberEmail)
        {
            return session.CreateCriteria(typeof(Member))
                .Add(Expression.Eq("memberEmail", memberEmail))
                .UniqueResult<Member>();
        }
        public static Member GetByHash(ISession session, string memberHash)
        {
            return session.CreateCriteria(typeof(Member))
                .Add(Expression.Eq("memberHash", memberHash))
                .UniqueResult<Member>();
        }
        public static Member GetByFBID(ISession session, string memberFBID)
        {
            return session.CreateCriteria(typeof(Member))
                .Add(Expression.Eq("memberFBID", memberFBID))
                .UniqueResult<Member>();
        }
    }
}