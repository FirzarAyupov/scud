using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scud
{
    public class GetEventListByDatetimeResult
    {
        public string DeviceCaption { get; set; }
        public string EventName { get; set; }
        public int EventPriority { get; set; }
        public string EventTime { get; set; }
        public int EventType { get; set; }
        public int ID { get; set; }
        public int IDDevice { get; set; }
        public int IDKey { get; set; }
        public int IDPart { get; set; }
        public int IDRelay { get; set; }
        public int IDStub { get; set; }
        public string KeyCaption { get; set; }
        public string PartCaption { get; set; }
        public string Person { get; set; }
        public string RelayCaption { get; set; }
        public string StubCaption { get; set; }
    }

    public class Root
    {
        public List<GetEventListByDatetimeResult> GetEventListByDatetimeResult { get; set; }
        public int result { get; set; }

        public List<GetEventListByDatetimeResult> GetEvent(String eventName) {
            List<GetEventListByDatetimeResult> result = new List<GetEventListByDatetimeResult>();

            foreach (GetEventListByDatetimeResult ev in this.GetEventListByDatetimeResult)
            {
                if (ev.EventName == eventName)
                {
                    result.Add(ev);
                }
            }
            return result;
        }
    }
}