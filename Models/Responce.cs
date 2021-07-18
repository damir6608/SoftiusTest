using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class Responce
    {
        [Required(ErrorMessage ="Пожалуйста введите количество студентов.")]
        public int StudentsNum { get; set; }
        [Required(ErrorMessage = "Пожалуйста укажите новость.")]
        public string Event { get; set; }


    }
}
