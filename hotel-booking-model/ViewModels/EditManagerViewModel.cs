using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.ViewModels
{
    public class EditManagerViewModel
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ManagerPhone { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string BusinessEmail { get; set; }
        [Required]
        public string BusinessPhone { get; set; }
        [Required]
        public string CompanyAddress { get; set; }
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string AccountNumber { get; set; }
    }
}
