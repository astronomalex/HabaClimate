using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HabaClimate.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        
        [Display(Name = "Имя")]
        [StringLength(5)]
        [Required(ErrorMessage = "Длина имени не менее 5 символов")]
        public string Name { get; set; }
        
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Номер телефона")]
        [StringLength(10)]
        [Required(ErrorMessage = "Номер телефона не менее 10 цифр")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        
        public List<OrderDetail> OrderDetails { get; set; }
    }

}