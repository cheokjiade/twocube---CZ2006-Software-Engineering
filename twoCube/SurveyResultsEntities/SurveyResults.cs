using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.SurveyResultsEntities
{
    public class SurveyResults
    {
        public string surveyTitle { get; set; }
        public string surveyDescription { get; set; }
        public int noOfRespondents { get; set; }
        public List<Questions> questionList { get; set; }

        public SurveyResults()
        {
            questionList = new List<Questions>();
        }
    }
}