using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aStoreServer.Models
{
    /// <summary>
    /// Сущность отдела 
    /// </summary>
    public class Department 
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Ссылка
        /// </summary>
        public int? DepGroupId { get; set; }
        /// <summary>
        /// Сущность группы отдела
        /// </summary>
        [ForeignKey(nameof(DepGroupId))]
        [JsonIgnore]
        DepGroup? DepGroupItem { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Описание отдела
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }
}


}
