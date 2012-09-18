using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.SurveyResultsEntities
{
    public class Questions
    {
        public List<Options> optionList { get; set; }

        public Questions()
        {
            optionList = new List<Options>();
        }
    }
}