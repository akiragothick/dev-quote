using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevQuote.API.Models
{
    public class User
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] Para no generar identity
        public int id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string email { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string password { get; set; }
    }
}
