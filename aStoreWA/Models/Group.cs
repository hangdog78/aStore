using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Models
{
    /// <summary>
    ///  �������� ������/���������
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
        ///  ������ �� ������/���������
        /// </summary>
        public int? GroupId {get; set; }

        /// <summary>
        ///  �������� ������/���������
        /// </summary>
        [ForeignKey(nameof(GroupId))]
        [JsonIgnore]
       // public Group? GroupItem { get; set; }

        // ������������ ���������.
        public virtual Group? Parent { get; set; }

        // �������� ���������.        
        public virtual ICollection<Group> Children { get; set; }

        // �������� � ���������.
        public virtual ICollection<Entity> Entitys { get; set; }

        /// <summary>
        ///  �������� ������/���������
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        ///  �������� ������/���������
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
