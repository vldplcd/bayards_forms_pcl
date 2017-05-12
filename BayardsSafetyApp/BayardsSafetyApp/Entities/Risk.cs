using System.Collections.Generic;
using SQLite;

namespace BayardsSafetyApp.Entities
{
    [Table("Risks")]
    public class Risk
    {

        [PrimaryKey, Column("id_r"), Unique]
        public string Id_r { get; set; }
        [Column("content")]
        public string Content { get; set; }
        public List<string> Media { get; set; }
        [Column("parent_s")]
        public string Parent_s { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [PrimaryKey, Column("lang")]
        public string Lang { get; set; }
    }
}
