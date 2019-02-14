using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGtt.Models
{
    public class Jira
    {
        public long id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string proyect { get; set; }

        public string issue { get; set; }

        public string component { get; set; }

        public string description { get; set; }

        public string url { get; set; }

        public long iduser { get; set; }
    }
}
