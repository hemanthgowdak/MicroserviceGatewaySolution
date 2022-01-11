using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Entity
{
    public class Customer:BaseEntity
    {

        public string Name { get; set; }

        public string Contact { get; set; }


        public string City { get; set; }


        public string Email { get; set; }

       

    }
}
