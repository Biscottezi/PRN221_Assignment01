using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderObject
    {
        public OrderObject()
        {
            OrderDetails = new HashSet<OrderDetailObject>();
        }

        public int OrderId { get; set; }
        public int? MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }

        public virtual MemberObject Member { get; set; }
        public virtual ICollection<OrderDetailObject> OrderDetails { get; set; }
    }
}
