using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClientWithBrowser.Models
{
    public class User
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public Email Email { get; set; }
    }
}
