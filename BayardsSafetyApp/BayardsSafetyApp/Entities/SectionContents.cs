using System.Collections.Generic;
using SQLite;

namespace BayardsSafetyApp.Entities
{
    [Table("section_contents")]
    public class SectionContents
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Column("section")]
        public Section Section { get; set; }
        [Column("risk")]
        public List<Risk> Risks { get; set; }
        [Column("subsection")]
        public List<Section> Subsections { get; set; }
    }
}
