using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevQuote.API.Entity
{
    public class Message
    {
        public string type { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public bool ExistsMessages() => Messages.Count > 0;
        public void Success() => type = "success";
        public void Warning() => type = "warning";
        public void Error() => type = "error";
        public void NotFound() => type = "not found";
        public void BadRequest() => type = "bad request"; 
    }
}
