using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Util.Pattern.Encryptor
{
    public class Security
    {
        //encrypt fun takes the string to be encrypted and passward as a parameter and
        //return encrypted string 
        public static string Encrypt(string p_plainText, string p_passPhrase, string p_salt)
        {
            try
            {
                var t_salt = p_salt; // can be any string
                var t_hashAlgorithm = "SHA1"; // can be "MD5"
                var t_passwordIterations = 2; // can be any number
                var t_initVector = "51cgc5D4e5F6gbc43"; // must be 16 bytes
                var t_keySize = 256; // can be 192 or 128


                var initVectorBytes = Encoding.ASCII.GetBytes(t_initVector);
                var saltBytes = Encoding.ASCII.GetBytes(t_salt);


                var plainTextBytes = Encoding.UTF8.GetBytes(p_plainText);

                var password = new PasswordDeriveBytes(
                    p_passPhrase,
                    saltBytes,
                    t_hashAlgorithm,
                    t_passwordIterations);

                var keyBytes = password.GetBytes(t_keySize / 8);

                var symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;


                var encryptor = symmetricKey.CreateEncryptor(
                    keyBytes,
                    initVectorBytes);

                var memoryStream = new MemoryStream();

                var cryptoStream = new CryptoStream(memoryStream,
                    encryptor,
                    CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);


                cryptoStream.FlushFinalBlock();


                var cipherTextBytes = memoryStream.ToArray();


                memoryStream.Close();
                cryptoStream.Close();


                var t_cipherText = Convert.ToBase64String(cipherTextBytes);


                return t_cipherText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string Decrypt(string p_cipherText, string p_passPhrase, string p_salt)
        {
            try
            {
                var t_salt = p_salt;
                var t_hashAlgorithm = "SHA1";
                var t_passwordIterations = 2;
                var t_initVector = "51cgc5D4e5F6gbc43";
                var t_keySize = 256;


                var initVectorBytes = Encoding.ASCII.GetBytes(t_initVector);
                var saltBytes = Encoding.ASCII.GetBytes(t_salt);


                var cipherTextBytes = Convert.FromBase64String(p_cipherText);

                var password = new PasswordDeriveBytes(
                    p_passPhrase,
                    saltBytes,
                    t_hashAlgorithm, t_passwordIterations);


                var keyBytes = password.GetBytes(t_keySize / 8);

                var symmetricKey = new RijndaelManaged();


                symmetricKey.Mode = CipherMode.CBC;


                var decryptor = symmetricKey.CreateDecryptor(
                    keyBytes,
                    initVectorBytes);

                var memoryStream = new MemoryStream(cipherTextBytes);


                var cryptoStream = new CryptoStream(memoryStream,
                    decryptor,
                    CryptoStreamMode.Read);


                var plainTextBytes = new byte[cipherTextBytes.Length];


                var decryptedByteCount = cryptoStream.Read(plainTextBytes,
                    0,
                    plainTextBytes.Length);

                memoryStream.Close();
                cryptoStream.Close();


                var t_plainText = Encoding.UTF8.GetString(plainTextBytes,
                    0,
                    decryptedByteCount);


                return t_plainText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Decrypt(string p_cipherText, string p_passPhrase)
        {
            try
            {
                return Decrypt(p_cipherText, p_passPhrase, "@U$win");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Encrypt(string p_plainText, string p_passPhrase)
        {
            try
            {
                return Encrypt(p_plainText, p_passPhrase, "@U$win");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string EncryptPassword(string plainTextPassw)
        {
            try
            {
                return Encrypt(plainTextPassw, "nhanvien", "@U$win");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}