using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.ViewModels
{
    public class NewCustomerViewModel
    {
        //no need for other functions like to List
        public IEnumerable<MembershipType> MembershipTypes { get; set; } 
        //from Customer Model for only view
        public Customer Customer { get; set; }
    }
}