using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SICLTests
{
    public class RSADecrypt
    {
        string exponentCifered = @"AQAB";
        string modulusCifered = @"qggvlMT/9aYVgBz71c4PjQF+gd/d7xMcHWhJssU7t98/ypMYTMTq7D2nsbM0ZEBkoMPrYC6cZARcLVZ1kOQvLQ==";
        string pCifered = @"xrDQpgmWRhhtganNdBszHpsRm8t7WCJfOet6qZr+qfs=";
        string qCifered = @"2xM7OVPF9aCLkNZX489+wfxMWpBaGdtB8ay5YijxKvc=";
        string dpCifered = @"xQzuoPy5EGOBlyq0HAYtuJjJ6dzwQwQztNmZGUQidKk=";
        string dqCifered = @"rp3EjewdFKxTsi12voksAtjjzyfR+VwPUt+WoAv8Nn8=";
        string inverseqCifered = @"HQpFONw9FgB9o+dDWOCH+9qUzDTUT/Q7d9o+59WQ1GA=";
        string dCifered = @"I7m4lZ+W0DxnRBXS7CdxqQTpWcx5yyPOwncJFSDP3WAZNfHvio4KUdFVL6ZI7tl88KSViKZbfEvXB17FsCSfWQ==";

        byte[] b64_exponent;
        byte[] b64_modulusBytes;
        byte[] b64_pBytes;
        byte[] b64_qBytes;
        byte[] b64_dpBytes;
        byte[] b64_dqBytes;
        byte[] b64_inverseqBytes;
        byte[] b64_dBytes;

        //byte[] utf_modulusCifered;
        //byte[] utf_pCifered;
        //byte[] utf_qCifered;
        //byte[] utf_dpCifered;
        //byte[] utf_dqCifered;
        //byte[] utf_inverseqCifered;
        //byte[] utf_dCifered;



        [Test]
        public void Test1()
        {
            b64_exponent        = Convert.FromBase64String(exponentCifered);
            b64_modulusBytes    = Convert.FromBase64String(modulusCifered);
            b64_pBytes          = Convert.FromBase64String(pCifered);
            b64_qBytes          = Convert.FromBase64String(qCifered);
            b64_dpBytes         = Convert.FromBase64String(dpCifered);
            b64_dqBytes         = Convert.FromBase64String(dqCifered);
            b64_inverseqBytes   = Convert.FromBase64String(inverseqCifered);
            b64_dBytes          = Convert.FromBase64String(dCifered);

            var result1 = Decryption(@"IlmhPFKroDuK4AUtBGfaf5J6791DzMenkUBEXfRwZ7rmBHswHTf02LAba/Hs+rsh3wL6dpMQlEhlaIAVHaZZsw==");
            var result2 = Decryption(@"AMbsYR1pq9WYUj3mdqKvJj7tMznqBAcZLxM2C6WzNEUOqKD/qdEE76bNJPmYFKwVei2rhuHFsxh7nUzXmVKRdw==");
            var result3 = Decryption(@"J1jnq551phV+W4MVzE5caXIHqM3E0gz/t9PVtorqvDVqfne8CCF9UQiEk33Rssi1IEz6JH8Fd8ZAvnX3UWe5Vw==");


            Console.WriteLine($"Frase1:\n{result1}\nFrase2:\n{result2}\nFrase3:\n{result3}\nDone");
        }

        public string Decryption(string strText)
        {
            var base64Encrypted = strText;

            using (var rsa = new RSACryptoServiceProvider(512))
            {
                try
                {
                    var P = new RSAParameters()
                    {
                        D = b64_dBytes,
                        DP = b64_dpBytes,
                        DQ = b64_dqBytes,
                        Exponent = b64_exponent,
                        InverseQ = b64_inverseqBytes,
                        Modulus = b64_modulusBytes,
                        P = b64_pBytes,
                        Q = b64_qBytes
                    };               
                    rsa.ImportParameters(P);

                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, false);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                catch (Exception)
                {

                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
            return null;
        }

    }
}
