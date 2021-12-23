using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace курсовой
{
    class PasswordWork
    {
        internal Classes.CommandBD CommandBD
        {
            get => default;
            set
            {
            }
        }

        public string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer;
            using (Rfc2898DeriveBytes b = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = b.Salt;
                buffer = b.GetBytes(0x20);  //В параметре количество байтов псевдослучайного ключа
            }
            byte[] byt = new byte[0x31];
            Buffer.BlockCopy(salt, 0, byt, 1, 0x10);
            Buffer.BlockCopy(buffer, 0, byt, 0x11, 0x20);
            return Convert.ToBase64String(byt);
        }
        public bool HashToPassword(string hash, string password)
        {
            byte[] buf;
            byte[] s = Convert.FromBase64String(hash);
            byte[] d = new byte[0x10];
            Buffer.BlockCopy(s, 1, d, 0, 0x10);
            byte[] buf1 = new byte[0x20];
            Buffer.BlockCopy(s, 0x11, buf1, 0, 0x20);
            using (Rfc2898DeriveBytes b = new Rfc2898DeriveBytes(password, d, 0x3e8))
            {
                buf = b.GetBytes(0x20);
            }
            bool fl = true;
            for (int i = 0; i < buf.Length; i++)
                if (buf[i] != buf1[i])
                    fl = false;
            return fl;
        }
    }
}
