using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aStoreServer.Models
{
    public class OperationsProgress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("OperationStateId")]
        public int OperationStateId { get; set; }
        [Column("DepartmentId")]
        public int DepartmentId { get; set; }
        [NotMapped]
        Department DepartmentItem { get; set; }
        [Column("WorkerId")]
        public int WorkerId { get; set; }
        [NotMapped]
        Worker WorkerItem { get; set; }
        [Column("RouteStageId")]
        public int RouteStageId { get; set; }
        [NotMapped]
        RoutStage routStageItem { get; set; }
    }
}
