using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    [Serializable]
    public class Cartitem
    {
        public Product Product { set; get; }
        public long Quantity { set; get; }
    }
}