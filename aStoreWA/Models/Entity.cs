using static System.Net.Mime.MediaTypeNames;
using System.Xml;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace aStoreServer.Models
{
    public class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Uiid")]
        public string Uiid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("GroupId")]
        public int GroupId { get; set; }
        [NotMapped]
        Group GroupItem { get; set; }

    }

}
