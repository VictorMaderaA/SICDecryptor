using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SICLib.Decryptor
{
    public class RSAService
    {



        public static string Decrypt(string strText, RSAParameters rSAParameters)
        {
            var base64Encrypted = strText;

            using (var rsa = new RSACryptoServiceProvider(512))
            {
                try
                {
                    rsa.ImportParameters(rSAParameters);

                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, false);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                catch(Exception)
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
