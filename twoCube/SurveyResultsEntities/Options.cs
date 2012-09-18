using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoCube.SurveyResultsEntities
{
    public class Options
    {
        public int noOfRespondents { get; set; }

        //private
        public Options()
        {
            noOfRespondents=0;
        }
    }
}