using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
   public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }
    }
}
