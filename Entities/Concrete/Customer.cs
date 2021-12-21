using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    //Base class inherit edilirken interface den önce yazılır.

    //[Table("Customers")]
    public class Customer:User,IEntity
    {
        
        //public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
