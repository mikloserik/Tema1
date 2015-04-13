﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class User
    {
        private String username;
        private String password;
        private String role;

        public User(String username, String password, String role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }

        public String getRole()
        {
            return role;
        }
    }
}
