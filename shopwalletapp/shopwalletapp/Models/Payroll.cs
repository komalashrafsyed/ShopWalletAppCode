﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shopwalletapp.Models
{
    public class Payroll
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int? EmployeeId { get; set; }

        [Display(Name = "Payroll Date")]
        [DataType(DataType.Date)]
        public DateTime PayrollDate { get; set; }

        [Display(Name = "Pay Amount")]
        public double PayAmount { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}