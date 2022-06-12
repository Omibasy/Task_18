using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.Entity;

namespace Task_18
{
    static class Connect
    {
        public static MSSQLlocalDBEntities2 Verification(string login, string password)
        {
            MSSQLlocalDBEntities2 baseData = new MSSQLlocalDBEntities2();

            baseData.registre.Load();

            registre registre = baseData.registre.First();

             password = Hmacmd(password, registre.id);

            if (registre.UserName == login && registre.Password == password)
            {
                return baseData;
            }

            return null;
        }

        private static string Hmacmd(string input, int id)
        {
   

            StringBuilder textPassword = new StringBuilder();

            byte[] salt = Encoding.UTF8.GetBytes($"{id}");
            byte[] password = Encoding.UTF8.GetBytes(input);


            HMACMD5 hmacMD5 = new HMACMD5(salt);
            byte[] saltedHash = hmacMD5.ComputeHash(password);

            for (int i = 0; i < saltedHash.Length; i++)
            {
                textPassword.Append(saltedHash[i].ToString("x2"));
            }

            return textPassword.ToString();
        }
    }
}
