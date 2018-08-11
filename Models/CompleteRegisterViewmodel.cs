using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLRI.Mvc.Models
{
    public class CompleteRegisterViewmodel
    {

        public string RegisterDate { get; set; }
        public string CustomerName { get; set; }
        public int SubscriptionType { get; set; }
        public string Username { get; set; }
    }
}
