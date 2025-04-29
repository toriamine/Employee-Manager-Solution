using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Core.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        [MaxLength(50, ErrorMessage = "Имя не должно превышать 50 символов")]
        public string Name { get; set; }

        [Range(18, 65, ErrorMessage = "Возраст должен быть от 18 до 65 лет")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Отдел обязателен")]
        [MaxLength(100, ErrorMessage = "Название отдела не должно превышать 100 символов")]
        public string Department { get; set; }
    }
}