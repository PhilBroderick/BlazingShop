using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Data
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public DateTime AppointmentDate { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerEMail { get; set; }

        [Required]
        public string CustomerPhone { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
