using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevQuote.API.DataTransferObject
{
    public class User
    {
        public int id { get; set; }

        public string email { get; set; }

        public string password { get; set; }
        public string token { get; set; }
    }
}
