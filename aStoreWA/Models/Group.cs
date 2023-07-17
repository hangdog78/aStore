using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Models
{
    /// <summary>
    ///  Сущность группы/категории
    /// </summary>
    public class Group
    {
        /// <summary>
        ///  Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        ///  Ссылка на группы/категории
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        ///  Сущность группы/категории
        /// </summary>
        [ForeignKey(nameof(GroupId))]
        [JsonIgnore]
        [NotMapped]

        public Group? Parent { get; set; }

        /*// Дочерние категории.        
        public virtual ICollection<Group>? Children { get; set; }*/

        // Продукты в категории.
        [NotMapped]
        public ICollection<Entity>? Entities { get; set; }

        /// <summary>
        ///  Название группы/категории
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        ///  Название группы/категории
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }

        public Group()
        {
            //Children = new List<Group>();
            Entities = new List<Entity>();
        }

    }

}
