﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1
{
    public static class Crypto
    {
       public static string hash(string value)
        {
            return Convert.ToBase64String(
               System.Security.Cryptography.SHA256.Create()
               .ComputeHash(Encoding.UTF8.GetBytes(value))
);
        }


    }
}