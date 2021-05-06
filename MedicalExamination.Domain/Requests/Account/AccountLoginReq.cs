using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalExamination.Domain.Requests.Account
{
    public class AccountLoginReq
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Sai định dạng username, xin mời kiểm tra lại")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
