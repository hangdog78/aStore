using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Models
{
    public class PositionRules
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("PositionRuleId")]
        public int PositionRuleId { get; set; }
        [NotMapped]
        public WorkerPosition WorkerPositionItem { get; set; }
        [Column("Read")]
        public bool Read {get; set; }
        [Column("Write")]
        public bool Write {get; set; }
        [Column("Delete")]
        public bool Delete {get; set; }
        
    }

}
