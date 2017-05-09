using System.Collections.Generic;

namespace BayardsSafetyApp.Entities
{
    public class Risk : SafetyObject
    {
        public string Id_r { get; set; }
        public string Content { get; set; }
        public List<string> Media { get; set; }
    }
}
