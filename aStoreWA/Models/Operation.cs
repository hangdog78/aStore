using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aStoreServer.Models
{
    /// <summary>
    /// Сущность операции 
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Id 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Ссылка на группу операций
        /// </summary>
        public int? GroupOperationId { get; set; }

        /// <summary>
        /// Сущность группы операций
        /// </summary>
        [ForeignKey(nameof(GroupOperationId))]
        [JsonIgnore]
        public Group? GroupOperation { get; set; }

        /// <summary>
        /// Название операции
        /// </summary>
        [Column("OperationName")]
        public string OperationName { get; set; }

        /// <summary>
        /// Описание операции
        /// </summary>
        [Column("OperationDescription")]
        public string OperationDescription { get; set; } 
    }

}

