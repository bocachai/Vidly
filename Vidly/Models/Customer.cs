using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Please enter the customer's name")]
        [StringLength (255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display (Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [MinMembershipAge]
        public DateTime? DateOfBirth { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display (Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}