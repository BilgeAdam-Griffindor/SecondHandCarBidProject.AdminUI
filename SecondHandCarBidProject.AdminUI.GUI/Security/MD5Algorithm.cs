using System.Security.Cryptography;
using System.Text;

namespace SecondHandCarBidProject.AdminUI.GUI.Security
{
    public static class MD5Algorithm
    {
        public static string md5AlgoritmExtension(this string metin)
        {

            metin += "!!Griffindor!!!";
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(metin));
            byte[] sonuc = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < sonuc.Length; i++)
            {
                strBuilder.Append(sonuc[i].ToString("x4"));
            }
            return strBuilder.ToString();

        }
    }
}
