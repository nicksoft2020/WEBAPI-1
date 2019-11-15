using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    /// <summary>
    /// Using for sending response to client.
    /// </summary>
    public class Response
    {
        public string Status { set; get; }
        public string Message { set; get; }
        public string FullName { get; set; }
    }
}
