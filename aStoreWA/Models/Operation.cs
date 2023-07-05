using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aStoreServer.Models
{
    public class Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("GroupOperation")]
        public int? GroupOperationId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public Group? GroupOperation { get; set; }

        [Column("OperationName")]
        public string OperationName { get; set; } = "";

        [Column("OperationDescription")]
        public string OperationDescription { get; set; } = "";
    }

}

