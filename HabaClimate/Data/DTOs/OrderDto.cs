using System;
using System.Collections.Generic;
using HabaClimate.Data.Models;

namespace HabaClimate.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}