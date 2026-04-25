using System;

namespace MSFD_SecureDataApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create users
            var admin = new User { Username = "AdminUser", Role = "Admin" };
            var user = new User { Username = "BasicUser", Role = "User" };

            // Initialize Secure Storage and set up the encryption
            // Note: THIS IS A DEMO. In a real application, you would want to handle encryption keys securely and not hard-code them.
            var storage = new SecureStorage();
            byte[] encryptionKey;
            byte[] initializationVector;

            using(var aes = System.Security.Cryptography.Aes.Create())
            {
                aes.GenerateKey();
                aes.GenerateIV();
                encryptionKey = aes.Key;
                initializationVector = aes.IV;

                // Store the encrypted data
                storage.StoreData("Sensitive Information", aes.Key, aes.IV);
            }

            // Attempt data retrieval as an Admin
            try
            {
                string adminData = storage.RetrieveData(admin, encryptionKey, initializationVector);
                Console.WriteLine($"Admin Access: {adminData}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Admin Error: {ex.Message}");
            }

            // Attempt data retrival as a Basic User
            try
            {
                string userData = storage.RetrieveData(user, encryptionKey, initializationVector);
                Console.WriteLine($"Admin Access: {userData}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"User Error: { $"To access this data, you need Admin privileges. {ex.Message}" }");
            }
        }
    }
}