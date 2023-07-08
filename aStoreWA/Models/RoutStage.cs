using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aStoreServer.Models
{

    /// <summary>
    /// �������� ����� ��������
    /// </summary>
    public class RoutStage
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// ������ �� �������
        /// </summary>
        public int? EntityRouteId {get; set; }

        /// <summary>
        /// �������� ��������
        /// </summary>
        [ForeignKey(nameof(EntityRouteId))]
        [JsonIgnore]
        public EntityRoute? EntityRouteItem { get; set; }

        /// <summary>
        /// ��������� �� ������� �������
        /// </summary>
        [Column("Index")]
        public int Index {get; set; }

        /// <summary>
        /// ������ �� ��������
        /// </summary>
        public int? OperationId { get; set; }

        /// <summary>
        /// �������� ��������
        /// </summary>
        [ForeignKey(nameof(OperationId))]
        [JsonIgnore]
        public Operation? OperationItem { get; set; }


        /// <summary>
        /// �������� ����� ��������
        /// </summary>
        [Column("Description")]
        public string Description {get; set; }

         
    }

}
