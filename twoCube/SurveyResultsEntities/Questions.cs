using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.SurveyResultsEntities
{
    public class Questions
    {
        public string questionTitle { get; set; }
        public int questionType { get; set; }
        public List<Options> optionList { get; set; }

        public Questions()
        {
            optionList = new List<Options>();
        }
    }
}