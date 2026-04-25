using System;
using System.Security.Cryptography;
using System.Text;


namespace MSFD_SecureDataApp
{
    public class SecureStorage
    {
        private string _encryptedData;

        // Encrypt and store data
        // Note: THIS IS A DEMO. In a real application, you want to implement proper key management and secure storage of keys.
        public void StoreData(string data, byte[] key, byte[] iv)
        {
            _encryptedData = Convert.ToBase64String(Encrypt(data, key, iv));
        }

        // Only Admin users can retrieve the data
        // Note: THIS IS A DEMO. In a real application, you want to implement proper authentication and authorization mechanisms.
        public string RetrieveData(User user, byte[] key, byte[] iv)
        {
            if (user.Role != "Admin")
                throw new UnauthorizedAccessException("Access denied. Admin role required.");

            return Decrypt(Convert.FromBase64String(_encryptedData), key, iv);
        }

        // Encryption method using AES symmetric encryption 
        // Note: THIS IS A DEMO. In a real application, key management would be crucial and should be handled securely.
        private static byte[] Encrypt(string data, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new System.IO.MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (var writer = new System.IO.StreamWriter(cs))
                    {
                        writer.Write(data);
                    }
                    return ms.ToArray();
                }
            }
        }

        // Decryption method using AES symmetric encryption
        // Note: THIS IS A DEMO. In a real application, key management would be crucial and should be handled securely.
        private static string Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new System.IO.MemoryStream(data))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var reader = new System.IO.StreamReader(cs))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}