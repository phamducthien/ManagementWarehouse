using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Util.Pattern.Encryptor
{
    public class FileCryptographyUtil
    {
        /// <summary>
        ///     Steve Lydford - 12/05/2008.
        ///     Encrypts a file using Rijndael algorithm.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        public static void EncryptFile(string inputFile, string outputFile, string password)
        {
            try
            {
                //string password = @"myKey123"; // Your Key Here
                //UnicodeEncoding UE = new UnicodeEncoding();
                //byte[] passBytes = UE.GetBytes(password);
                //byte[] key = GetBytes(passBytes);
                var key = GetBytes(password);
                var ivKey = new byte[key.Length];
                Array.Copy(key, ivKey, key.Length);

                var cryptFile = outputFile;
                using (var fsCrypt = new FileStream(cryptFile, FileMode.Create))
                {
                    using (var RMCrypto = new RijndaelManaged())
                    {
                        //CryptoStream cs = new CryptoStream(fsCrypt,
                        //    RMCrypto.CreateEncryptor(key, key),
                        //    CryptoStreamMode.Write);

                        RMCrypto.KeySize = key.Length * 8;
                        RMCrypto.Key = key;
                        RMCrypto.BlockSize = ivKey.Length * 8;
                        RMCrypto.IV = ivKey;

                        using (var icrypto = RMCrypto.CreateEncryptor())
                        {
                            using (var cs = new CryptoStream(fsCrypt, icrypto, CryptoStreamMode.Write))
                            {
                                using (var fsIn = new FileStream(inputFile, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                        cs.WriteByte((byte) data);


                                    fsIn.Close();
                                    cs.Close();
                                    fsCrypt.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        ///     Steve Lydford - 12/05/2008.
        ///     Decrypts a file using Rijndael algorithm.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        public static void DecryptFile(string inputFile, string outputFile, string password)
        {
            try
            {
                //string password = @"myKey123"; // Your Key Here

                var key = GetBytes(password);
                var ivKey = new byte[key.Length];
                Array.Copy(key, ivKey, key.Length);

                using (var fsCrypt = new FileStream(inputFile, FileMode.Open))
                {
                    using (var RMCrypto = new RijndaelManaged())
                    {
                        //CryptoStream cs = new CryptoStream(fsCrypt,
                        //    RMCrypto.CreateDecryptor(key, key),
                        //    CryptoStreamMode.Read);

                        RMCrypto.KeySize = key.Length * 8;
                        RMCrypto.Key = key;
                        RMCrypto.BlockSize = ivKey.Length * 8;
                        RMCrypto.IV = ivKey;

                        using (var icrypto = RMCrypto.CreateDecryptor())
                        {
                            using (var cs = new CryptoStream(fsCrypt, icrypto, CryptoStreamMode.Read))
                            {
                                using (var fsOut = new FileStream(outputFile, FileMode.Create))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                        fsOut.WriteByte((byte) data);

                                    fsOut.Close();
                                    cs.Close();
                                    fsCrypt.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected static byte[] GetBytes(string password)
        {
            byte[] resBytes = null;

            var Salt = Encoding.Unicode.GetBytes(password);
            var pwdGen = new Rfc2898DeriveBytes(password, Salt, 10000);

            resBytes = pwdGen.GetBytes(256 / 8);

            return resBytes;
        }

        protected static byte[] GetBytes(byte[] input)
        {
            var keyLeng1 = 128 / 8;
            var keyLeng2 = 192 / 8;
            var keyLeng3 = 256 / 8;
            var returnLeng = keyLeng1;

            byte[] resBytes = null;

            var inputLeng = input.Length;

            resBytes = new byte[returnLeng];
            Array.Copy(input, resBytes, returnLeng);
            return resBytes;
        }
    }
}