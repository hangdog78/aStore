using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace aStoreServer.Models
{
    /// <summary>
    /// Сущность группы отдела 
    /// </summary>
    public class DepGroup
    {
        /// <summary>
        ///  Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        ///  Имя группы отдела
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }
    }
}
