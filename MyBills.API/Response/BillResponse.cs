using MyBills.API.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBills.API.Response
{
    public class BillResponse : ResponseGenerics
    {
        public List<BillViewModel> BillViewModelList { get; set; }
    }
}
