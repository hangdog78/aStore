using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aStoreServer.Models
{

    /// <summary>
    /// Сущность состояния операции
    /// </summary>
    public class OperationState
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Название состояния
        /// </summary>
        [Column("State")]
        public string State { get; set; }
    }
}
