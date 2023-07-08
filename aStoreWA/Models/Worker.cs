using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Models
{
    /// <summary>
    /// �������� ��������
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
        /// ������
        /// </summary>
        [Column("Password")]
        [Required]
        public string Password {get; set; }

        /// <summary>
        /// ���
        /// </summary>
        [Column("Name")]
        [Required]
        public string Name {get; set; }

        /// <summary>
        /// ������ �� ������ ������ 
        /// </summary>
        public int? DepId {get; set; }

        /// <summary>
        /// �������� ������ ������ 
        /// </summary>
        [ForeignKey(nameof(DepId))]
        [JsonIgnore]
        DepGroup? DepGroup { get; set; }
        
                 
    }

}
