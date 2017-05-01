using System.Collections.Generic;

namespace BayardsSafetyApp.Entities
{
    public class Risk : SafetyObject
    {
        public string Text { get; set; }
        public List<string> Media { get; set; }
    }
}
