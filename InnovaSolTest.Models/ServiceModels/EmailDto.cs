using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaSolTest.Models.ServiceModels
{
    public class EmailDto
    {
        public List<string> ToAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
