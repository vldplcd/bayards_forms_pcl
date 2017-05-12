using SQLite;

namespace BayardsSafetyApp.Entities
{
    [Table("section")]
    public class Section
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int _id { get; set; }
        [Column("id_s")]
        public string Id_s { get; set; }
        [Column("parent_s")]
        public string Parent_s { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("lang")]
        public string Lang { get; set; }

    }
}
