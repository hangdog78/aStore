using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Models
{
    public class EntityRoute 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("EntityId")]
        public int EntityId {get; set; }
        [NotMapped]
        public Entity EntityItem { get; set; }
        [Column("Name")]
        public string Name {get; set; }
        [Column("Description")]
        public string Description {get; set; }

    }

}
