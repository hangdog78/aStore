using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Models
{
    /// <summary>
    /// Сущность рабочего
    /// </summary>
    public class Worker 
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Column("Password")]
        [Required]
        public string Password {get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Column("Name")]
        [Required]
        public string Name {get; set; }

        /// <summary>
        /// Ссылка на группу отдела 
        /// </summary>
        public int? DepId {get; set; }

        /// <summary>
        /// Сущность группы отдела 
        /// </summary>
        [ForeignKey(nameof(DepId))]
        [JsonIgnore]
        DepGroup? DepGroup { get; set; }
        
                 
    }

}
