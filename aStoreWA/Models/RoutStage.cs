using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aStoreServer.Models
{

    /// <summary>
    /// Сущность этапа маршрута
    /// </summary>
    public class RoutStage
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Ссылка на маршрут
        /// </summary>
        public int? EntityRouteId {get; set; }

        /// <summary>
        /// Сущность маршрута
        /// </summary>
        [ForeignKey(nameof(EntityRouteId))]
        [JsonIgnore]
        public EntityRoute? EntityRouteItem { get; set; }

        /// <summary>
        /// Указатель на текущий порядок
        /// </summary>
        [Column("Index")]
        public int Index {get; set; }

        /// <summary>
        /// Ссылка на операцию
        /// </summary>
        public int? OperationId { get; set; }

        /// <summary>
        /// Сущность операции
        /// </summary>
        [ForeignKey(nameof(OperationId))]
        [JsonIgnore]
        public Operation? OperationItem { get; set; }


        /// <summary>
        /// Описание этапа маршрута
        /// </summary>
        [Column("Description")]
        public string Description {get; set; }

         
    }

}
