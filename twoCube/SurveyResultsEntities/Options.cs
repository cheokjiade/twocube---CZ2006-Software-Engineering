using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.SurveyResultsEntities
{
    public class Options
    {
        public string optionTitle { get; set; }
        public int noOfRespondents { get; set; }

        public String responseStr { get; set; }

        //private
        public Options()
        {
            noOfRespondents=0;
            //responseStr = "";
        }
    }
}