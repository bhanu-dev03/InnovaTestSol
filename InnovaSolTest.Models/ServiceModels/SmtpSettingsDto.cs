using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaSolTest.Models.ServiceModels
{
    public class SmtpSettingsDto
    {
        public string From { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Pwd { get; set; }
    }
}
