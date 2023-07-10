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
        public int? GroupId {get; set; }

        /// <summary>
        ///  Сущность группы/категории
        /// </summary>
        [ForeignKey(nameof(GroupId))]
        [JsonIgnore]
       // public Group? GroupItem { get; set; }

        // Родительская категория.
        public virtual Group? Parent { get; set; }

        // Дочерние категории.        
        public virtual ICollection<Group> Children { get; set; }

        // Продукты в категории.
        public virtual ICollection<Entity> Entitys { get; set; }

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
            Children = new List<Group>();
            Entitys = new List<Entity>();
        }

    }

}
