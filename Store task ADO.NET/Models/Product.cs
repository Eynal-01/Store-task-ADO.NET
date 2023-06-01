using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_task_ADO.NET.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Discount { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
    }
}
