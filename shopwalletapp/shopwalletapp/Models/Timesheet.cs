using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shopwalletapp.Models
{
    public class Timesheet
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Employee")]
        [Required]
        public int? EmployeeId { get; set; }

        [Display(Name = "Manager")]
        public int? ManagerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public double Hours { get; set; }

        [Display(Name = "Hourly Rate")]
        public double HourlyRate { get; set; }

        [Display(Name = "Task Description")]
        [Required]
        public int? TaskDescId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [ForeignKey("ManagerId")]
        public Employee Employee1 { get; set; }

        [ForeignKey("TaskDescId")]
        public TaskDesc TaskDesc { get; set; }
    }
}