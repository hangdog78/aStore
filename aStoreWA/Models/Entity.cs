using static System.Net.Mime.MediaTypeNames;
using System.Xml;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;

namespace aStoreServer.Models
{
    /// <summary>
    ///  Сущность объекта
    /// </summary>
    public class Entity
    {
        /// <summary>
        ///  Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        ///  Имя объекта
        /// </summary>
        [Column("Name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание объекта
        /// </summary>
        [Column("Description")]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Ссылка на группу/категорию объекта
        /// </summary>
        public int? GroupId { get; set; }
        /// <summary>
        /// Сущность категории объекта
        /// </summary>
     //   [ForeignKey(nameof(GroupItemId))]
        [JsonIgnore]
        //public virtual Group? Parent { get; set; }
        [NotMapped]
        public Group? Group { get; set; }

        public Entity()
        {
            // this.Id = Id;
            //  this.Name = Name;
            //  this.Description = Description;
            //Groups = new List<Group>();
        }
    }

}
