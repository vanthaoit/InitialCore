using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InitialCore.Service.ViewModels.Common;
using InitialCore.Service.ViewModels.Product;
using InitialCore.Data.Enums;
using InitialCore.Utilities.Extensions;

namespace InitialCore.Models
{
    public class CheckoutViewModel : BillViewModel
    {
        public List<ShoppingCartViewModel> Carts { get; set; }
        //public List<EnumModel> PaymentMethods
        //{
        //    get
        //    {
        //        return ((PaymentMethod[])Enum.GetValues(typeof(PaymentMethod)))
        //            .Select(c => new EnumModel
        //            {
        //                Value = (int)c,
        //                Name = c.GetDescription()
        //            }).ToList();
        //    }
        //}
    }
}
