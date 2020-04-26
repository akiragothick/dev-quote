using DevQuote.API.Entity;
using System.Collections.Generic;

namespace DevQuote.API.Base
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<T> DataList { get; set; }
        public Message Message { get; set; } = new Message();

        public bool ShouldSerializeData() => !(Data == null);
        public bool ShouldSerializeDataList() => !(DataList == null || DataList.Count.Equals(0));
        public bool ShouldSerializeMessage() => !(Message == null);
    }
}
