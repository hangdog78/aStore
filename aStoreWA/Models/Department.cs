using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aStoreServer.Models
{
    /// <summary>
    /// �������� ������ 
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
        /// ������
        /// </summary>
        public int? DepGroupId { get; set; }
        /// <summary>
        /// �������� ������ ������
        /// </summary>
        [ForeignKey(nameof(DepGroupId))]
        [JsonIgnore]
        DepGroup? DepGroupItem { get; set; }

        /// <summary>
        /// �������� ������
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// �������� ������
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }
}


}
