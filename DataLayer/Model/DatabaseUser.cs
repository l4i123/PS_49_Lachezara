using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    public class DatabaseUser : User
    {

        [Key]//Първият атрибут, показва, че това ще бъде ключ в базата данни,
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//вторият, че стойността на полето ще бъде автоматично генерирано.
        public override int Id { get; set; } // Идентификатор на потребителя
    }
}
