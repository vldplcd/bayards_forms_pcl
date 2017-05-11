using SQLite;

namespace BayardsSafetyApp.Entities
{
    [Table("section")]
    public class Section : SafetyObject
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Column("id_s"), Unique]
        public string Id_s { get; set; }
        [Column("is_a_subsection")]
        public bool isASubsection { get; set; }

    }
}
