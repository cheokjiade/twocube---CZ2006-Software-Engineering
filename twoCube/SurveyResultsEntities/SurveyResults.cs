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
        public int avgTime { get; set; }
        public List<Questions> questionList { get; set; }
        public List<KeyValueResponse> browserBrowser { get; set; }
        public List<KeyValueResponse> browserOS { get; set; }
        public List<KeyValueResponse> countryCode { get; set; }
        public List<KeyValueResponse> language { get; set; }

        public SurveyResults()
        {
            questionList = new List<Questions>();
            browserBrowser = new List<KeyValueResponse>();
            browserOS = new List<KeyValueResponse>();
            countryCode = new List<KeyValueResponse>();
            language = new List<KeyValueResponse>();
        }
    }
}