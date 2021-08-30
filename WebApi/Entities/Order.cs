using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public DateTime OrderDate { get; set; }
        public float Price { get; set; }
    }
}