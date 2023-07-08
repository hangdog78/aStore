using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aStoreServer.Models
{
    /// <summary>
    /// Сущность этапа маршрутов выполняемые в данынй момент
    /// </summary>
    public class OperationsProgress
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Ссылка на состояние операции
        /// </summary>
        public int? OperationStateId { get; set; }

        /// <summary>
        /// Сущность состояния операции
        /// </summary>
        [ForeignKey(nameof(OperationStateId))]
        [JsonIgnore]
        public OperationState? OperationState { get; set; }


        /// <summary>
        /// Ссылка на отдел
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Cущность отдела
        /// </summary>
        [ForeignKey(nameof(DepartmentId))]
        [JsonIgnore]
        public Department? DepartmentItem { get; set; }

        /// <summary>
        /// Ссылка на рабочего
        /// </summary>
        public int? WorkerId { get; set; }

        /// <summary>
        /// Cущность рабочего
        /// </summary>
        [ForeignKey(nameof(WorkerId))]
        [JsonIgnore]
        public Worker? WorkerItem { get; set; }

        /// <summary>
        /// Cсылка на этап маршрута
        /// </summary>
        public int? RouteStageId { get; set; }

        /// <summary>
        /// Сущность этапа маршрута
        /// </summary>
        [ForeignKey(nameof(RouteStageId))]
        [JsonIgnore]
        public RoutStage? routStageItem { get; set; }
    }
}
