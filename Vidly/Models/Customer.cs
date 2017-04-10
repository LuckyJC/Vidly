using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        //data annotations- set parameters to be used in SQL
        [Required]
        [StringLength(255)]
        
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        
        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }
        
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        
        public MembershipType MembershipType { get; set; }
    }
}