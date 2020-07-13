using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestjsServer.Entities
{
    [Table("tblUsers")]
    public class DbUser
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [Required, StringLength(255)]
        public string Role { get; set; }
    }
}
