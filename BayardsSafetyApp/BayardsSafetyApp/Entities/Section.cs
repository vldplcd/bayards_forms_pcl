using SQLite;

namespace BayardsSafetyApp.Entities
{
    [Table("section")]
    public class Section
    {
        [PrimaryKey, Column("id_s")]
        public string Id_s { get; set; }
        [Column("parent_s")]
        public string Parent_s { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [PrimaryKey, Column("lang")]
        public string Lang { get; set; }

    }
}
