using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    //We have model for MembershipType For These data in order to have these in DropDownList/Edit/Create/Details
    //Model in Customer have Membershiptype in Membershitype have also different categories
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public string Name { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        
        public static readonly byte Unknown = 0;
        //the value assign in PayAsYouGo is based on Migration Sql = 1
        public static readonly byte PayAsYouGo = 1;
    }
}