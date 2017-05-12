using System.Collections.Generic;
using SQLite;

namespace BayardsSafetyApp.Entities
{
    [Table("Risks")]
    public class Risk
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int _id { get; set; }
        [Column("id_r"), Unique]
        public string Id_r { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Ignore]
        public List<string> Media { get; set; }
        [Column("parent_s")]
        public string Parent_s { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("lang")]
        public string Lang { get; set; }
    }
}
