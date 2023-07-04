using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aStoreServer.Models
{
    public class RoutStage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("DepEntityRouteId")]
        public int EntityRouteId {get; set; }
        [NotMapped]
        public EntityRoute EntityRouteItem { get; set; }
        [Column("Index")]
        public int Index {get; set; }
        [Column("DepOperation")]
        public int OperationId {get; set; }
        [NotMapped]
        public Operation OperationItem { get; set; }
        [Column("Description")]
        public string Description {get; set; }

         
    }

}
