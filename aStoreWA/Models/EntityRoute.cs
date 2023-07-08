using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Models
{
    /// <summary>
    ///  Сущность Маршрута
    /// </summary>
    public class EntityRoute 
    {
        /// <summary>
        ///  Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        ///  Ссылка на объект
        /// </summary>
        public int? EntityId {get; set; }

        /// <summary>
        ///  Сущность объекта
        /// </summary>
        [ForeignKey(nameof(EntityId))]
        [JsonIgnore]
        public Entity? EntityItem { get; set; }

        /// <summary>
        /// Название маршрута
        /// </summary>
        [Column("Name")]
        public string Name {get; set; }

        /// <summary>
        /// Описание маршрута
        /// </summary>
        [Column("Description")]
        public string Description {get; set; }

    }

}
