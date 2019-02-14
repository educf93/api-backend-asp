using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGtt.Models
{
    public class Certificates
    {

        public long id { get; set; }

        public string name { get; set; }

        public string entity { get; set; }

        public string alias { get; set; }

        public string serialNum { get; set; }

        public string subject { get; set; }

        public DateTime expireDate  { get; set; }

        public string password { get; set; }

        public long idOrg { get; set; }

        public string clientName { get; set; }

        public string emailRenov { get; set; }

        public string repo { get; set; }

        public string observations { get; set; }

        public string content { get; set; }

        public bool notice { get; set; }

        public bool ticketed { get; set; }
    }
}
