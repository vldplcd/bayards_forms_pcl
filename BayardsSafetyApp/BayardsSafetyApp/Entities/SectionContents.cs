using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayardsSafetyApp.Entities
{
    public class SectionContents
    {
        public Section Section { get; set; }
        public List<Risk> Risks { get; set; }
        public List<Section> Subsections { get; set; }
    }
}
