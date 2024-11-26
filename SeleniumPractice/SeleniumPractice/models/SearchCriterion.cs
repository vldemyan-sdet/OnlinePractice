using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPractice.models
{
    public class SearchCriterion
    {
        public string City { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Distance { get; set; }
        public string Rating { get; set; }
    }
}
