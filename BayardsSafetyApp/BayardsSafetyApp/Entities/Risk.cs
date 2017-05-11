using System.Collections.Generic;
using SQLite;

namespace BayardsSafetyApp.Entities
{
    [Table("Risks")]
    public class Risk : SafetyObject
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Column("id_r"), Unique]
        public string Id_r { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("media")]
        public List<string> Media { get; set; }
    }
}
