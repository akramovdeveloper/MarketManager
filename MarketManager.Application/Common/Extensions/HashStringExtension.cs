using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MarketManager.Application.Common.Extensions;
public static class HashStringExtension
{
    public static string GetHashedString(this string text)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            byte[] hashbytes = sha256.ComputeHash(bytes);
            text = Convert.ToBase64String(hashbytes);

        }
       return text;
    }
}
