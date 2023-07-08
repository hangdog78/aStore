using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System;

namespace aStoreServer.Models
{
    /// <summary>
    /// Сущность Qr-code
    /// </summary>
    public class QR
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Имя в Rr-code
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        // <summary>
        /// Описание в Rr-code
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Ссылка на объект
        /// </summary>
        public int? EntityId { get; set; }

        /// <summary>
        /// Сущность объекта
        /// </summary>
        [ForeignKey(nameof(EntityId))]
        [JsonIgnore]
        public Entity? Entity { get; set; }

        /// <summary>
        /// Путь до Rr-code
        /// </summary>
        [Column("Path")]
        public string Path { get; set; }
    }
}
