using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace twoCube.Entities
{
    public class Survey
    {
        public virtual int Id { get; set; }
        public virtual string surveyTitle { get; set; }
        public virtual string surveyDescription { get; set; }
        public virtual bool surveyStatus { get; set; }
        public virtual DateTime surveyCreated { get; set; }
        public virtual DateTime surveyStartDate { get; set; }
        public virtual DateTime surveyEndDate { get; set; }
        public virtual IList<SurveyQuestion> surveyQuestionList { get; set; }
        public virtual IList<Respondent> respondentList { get; set; }
        public Survey()
        {
            surveyQuestionList = new List<SurveyQuestion>();
            respondentList = new List<Respondent>();
            surveyCreated = DateTime.Now;
        }

        public virtual void AddSurveyQuestion(SurveyQuestion surveyQuestion)
        {
            surveyQuestionList.Add(surveyQuestion);
        }

        public virtual void AddRespondent(Respondent respondent)
        {
            respondentList.Add(respondent);
        }
        public static Survey GetById(ISession session, int id)
	        {
                return session.CreateCriteria(typeof(Survey))
	                .Add(Expression.Eq("Id", id))
                    .UniqueResult<Survey>();
	        }

    }
}