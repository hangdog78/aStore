using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Models
{
    public class Worker 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Password")]
        public string Password {get; set; }
        [Column("Name")]
        public string Name {get; set; }
        [Column("PositionId")]
        public int PositionId {get; set; }
        [NotMapped]
        public WorkerPosition PositionItem { get; set; }
        [Column("DepId")]
        public int DepId {get; set; }
        [NotMapped]
        DepGroup DepGroup { get; set; }
        
                 
    }

}
