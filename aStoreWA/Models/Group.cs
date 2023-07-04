using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Models
{
    public class Group 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Group")]
        public int GroupId {get; set; }
        [NotMapped]     
        public Group GroupItem { get; set; }
        [Column("Name")]
        public string Name {get; set; }
        [Column("Description")]
        public string Description {get; set; }

    }

}
