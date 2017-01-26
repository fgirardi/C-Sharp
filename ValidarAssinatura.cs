using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ValidarAssinatura
{
    class Program
    {

        private static bool ValidateWithCertificate(SignedXml signer)
        {
            var keyInfoEnumerator = signer.KeyInfo.GetEnumerator();

            while (keyInfoEnumerator.MoveNext())
            {
                var x509Data = keyInfoEnumerator.Current as KeyInfoX509Data;

                if (x509Data != null && x509Data.Certificates.Count > 0)
                    foreach (var cert in x509Data.Certificates)
                        if (signer.CheckSignature((X509Certificate2)cert, true))
                            return true;
            }

            return false;
        }


        static void Main(string[] args)
        {

            var docXml = new XmlDocument();
            docXml.PreserveWhitespace = true;
            try { docXml.Load("H:\\XXXX\\XXX\\XML\\999999999999999999999999999999999999999-nfe.xml"); }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                return;
            }

            var nfe = (XmlElement)docXml.GetElementsByTagName("NFe")[0];
            var signature = (XmlElement)nfe.GetElementsByTagName("Signature")[0];
            var signer = new SignedXml();

            signer.LoadXml(signature);
            Console.WriteLine(signer.CheckSignature());
            Console.WriteLine(ValidateWithCertificate(signer));
            Console.ReadKey();
        }
    }
}
