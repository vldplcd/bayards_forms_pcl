using SQLite;

namespace BayardsSafetyApp.Entities
{
    [Table("safety_object")]
    public class SafetyObject
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
        [Column("parent_s")]
        public string Parent_s { get; set; }
    }
}
