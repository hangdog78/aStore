using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Models
{
    public class WorkerPosition 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Name")]
        public string Name {get; set; }
         
    }

}
