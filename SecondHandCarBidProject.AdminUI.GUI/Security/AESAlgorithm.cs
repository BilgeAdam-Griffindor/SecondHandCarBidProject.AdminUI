using System.Security.Cryptography;

namespace SecondHandCarBidProject.AdminUI.GUI.Security
{
    public static class AESAlgorithm
    {
        //https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-6.0
        //TODO repeated values in the key. Might be better to change to a different one.
        private static readonly byte[] aes_key = new byte[] { 101, 115, 114, 97, 97, 108, 105, 99, 97, 110, 114, 101, 99, 97, 105, 101, 114, 101, 110, 101, 109, 114, 101, 103, 114, 121, 102, 105, 110, 100, 111, 114 };
        private static readonly byte[] aes_IV = new byte[] { 138, 249, 93, 4, 116, 193, 133, 130, 23, 137, 21, 115, 187, 87, 185, 85 };

        /// <summary>
        /// Encrpyts data with AES algorithm then converts it to Base64 string.
        /// </summary>
        /// <param name="data">Data you want to encrypt.</param>
        /// <returns>Encrypted data in Base64 string form.</returns>
        /// <exception cref="ArgumentNullException">When data is null or empty.</exception>
        public static string EncryptToBase64String(string data)
        {
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException("data is null");

            byte[] encrypted = EncryptStringToBytes_Aes(data, aes_key, aes_IV);

            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// Decrypts data with AES algorithm.
        /// </summary>
        /// <param name="data">Data you want to decrypt. Must be a Base64 string created by EncryptToBase64String.</param>
        /// <returns>Decrypted data.</returns>
        public static string DecryptBase64String(string data)
        {
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException("data is null");

            byte[] encrypted = Convert.FromBase64String(data);

            return DecryptStringFromBytes_Aes(encrypted, aes_key, aes_IV);
        }

        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            //if (plainText == null || plainText.Length <= 0)
            //    throw new ArgumentNullException("plainText");
            //if (Key == null || Key.Length <= 0)
            //    throw new ArgumentNullException("Key");
            //if (IV == null || IV.Length <= 0)
            //    throw new ArgumentNullException("IV");

            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            //if (cipherText == null || cipherText.Length <= 0)
            //    throw new ArgumentNullException("cipherText");
            //if (Key == null || Key.Length <= 0)
            //    throw new ArgumentNullException("Key");
            //if (IV == null || IV.Length <= 0)
            //    throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
