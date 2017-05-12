using SQLite;

namespace BayardsSafetyApp.Entities
{
    [Table("safety_object")]
    public class SafetyObject
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

    }
}
