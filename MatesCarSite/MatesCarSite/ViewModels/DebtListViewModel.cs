using MatesCarSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.ViewModels
{
    public class DebtListViewModel
    {

        public ApplicationUser LoanHolderRef { get; set; }
        public List<ApplicationUser> LoanDebtorRef { get; set; }
        public float Value { get; set; }
        public Route RouteRef { get; set; }

    }
}
