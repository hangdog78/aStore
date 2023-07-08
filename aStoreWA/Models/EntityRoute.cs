using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Models
{
    /// <summary>
    ///  �������� ��������
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
        ///  ������ �� ������
        /// </summary>
        public int? EntityId {get; set; }

        /// <summary>
        ///  �������� �������
        /// </summary>
        [ForeignKey(nameof(EntityId))]
        [JsonIgnore]
        public Entity? EntityItem { get; set; }

        /// <summary>
        /// �������� ��������
        /// </summary>
        [Column("Name")]
        public string Name {get; set; }

        /// <summary>
        /// �������� ��������
        /// </summary>
        [Column("Description")]
        public string Description {get; set; }

    }

}
