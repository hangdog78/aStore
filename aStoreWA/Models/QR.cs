using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace aStoreServer.Models
{
    public class QR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("QrInfo")]
        public string QrInfo { get; set; } = "";

        [NotMapped]
        [JsonIgnore]
        [Column("Entity")]
        public Entity? QREntity { get; set; }

        [Column("Path")]
        public string Path { get; set; } = "";
    }
}
