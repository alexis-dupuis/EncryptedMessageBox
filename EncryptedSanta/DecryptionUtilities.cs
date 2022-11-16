using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace EncryptedSanta
{
    public static class DecryptionUtilities
    {
        public static string ToDecryptedString(string encryptedText, RSACryptoServiceProvider rsa)
        {
            using (var inMs = new MemoryStream(Convert.FromBase64String(encryptedText)))
            {
                // Retrieve length of Key and IV in order to retrieve them
                byte[] LenK = new byte[4];
                byte[] LenIV = new byte[4];

                inMs.Seek(0, SeekOrigin.Begin);
                inMs.Read(LenK, 0, 3);
                inMs.Seek(4, SeekOrigin.Begin);
                inMs.Read(LenIV, 0, 3);

                int lenK = BitConverter.ToInt32(LenK, 0);
                int lenIV = BitConverter.ToInt32(LenIV, 0);

                // Retrieve aes IV + encrypted aes Key
                byte[] encryptedAesKey = new byte[lenK];
                byte[] aesIV = new byte[lenIV];
                
                inMs.Seek(8, SeekOrigin.Begin);
                inMs.Read(encryptedAesKey, 0, lenK);
                inMs.Seek(8 + lenK, SeekOrigin.Begin);
                inMs.Read(aesIV, 0, lenIV);

                // Decrypt aes key (from RSA)
                byte[] aesKey = rsa.Decrypt(encryptedAesKey, false);

                // Determine the start position of the cipher text (startC) and its length (lenC).
                int startC = lenK + lenIV + 8;
                int lenC = (int)inMs.Length - startC;

                // Use aes key and IV to decrypt the text
                byte[] encryptedCipher = new byte[lenC];
                inMs.Seek(startC, SeekOrigin.Begin);
                inMs.Read(encryptedCipher, 0, lenC);

                return Decrypt(encryptedCipher, aesKey, aesIV);
            }
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private static string Decrypt(byte[] encryptedCipher, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            using (Aes aes = new AesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream(encryptedCipher))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }
    }
}
