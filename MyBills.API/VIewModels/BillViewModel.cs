using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBills.API.VIewModels
{
    public class BillViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public DateTime DatePayed { get; set; }
    }
}
