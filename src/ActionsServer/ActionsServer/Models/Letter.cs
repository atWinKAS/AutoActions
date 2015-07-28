using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActionsServer.Models
{
    public class Letter
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}