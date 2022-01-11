using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Entity
{
    public class ProductDelivered:BaseEntity
    {


        public bool IsDeliverd { get; set; }

       
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }


    }
}
