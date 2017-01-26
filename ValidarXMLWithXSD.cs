using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ValidarXMLWithXSD
{
    public class ValidacaoXML
    {
        private bool falhou;
        public bool Falhou
        {
            get { return falhou; }
        }

        public bool ValidarXml(string xmlFilename, string schemaFilename)
        {
            // Define o tipo de validação
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            // Carrega o arquivo de esquema
            XmlSchemaSet schemas = new XmlSchemaSet();
            settings.Schemas = schemas;
            // Quando carregar o eschema, especificar o namespace que ele valida
            // e a localização do arquivo 
            schemas.Add(null, schemaFilename);
            // Especifica o tratamento de evento para os erros de validacao
            settings.ValidationEventHandler += ValidationEventHandler;
            // cria um leitor para validação
            XmlReader validator = XmlReader.Create(xmlFilename, settings);
            falhou = false;
            try
            {
                // Faz a leitura de todos os dados XML
                while (validator.Read()) { }
            }
            catch (XmlException err)
            {
                // Um erro ocorre se o documento XML inclui caracteres ilegais
                // ou tags que não estão aninhadas corretamente
                Console.WriteLine("Ocorreu um erro critico durante a validacao XML.");
                Console.WriteLine(err.Message);
                falhou = true;
            }
            finally
            {
                validator.Close();
            }
            return !falhou;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            falhou = true;
            // Exibe o erro da validação
            Console.WriteLine("Erros da validação : " + args.Message);
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ValidacaoXML validadorXML = new ValidacaoXML();
            Console.WriteLine("Validando o  arquivo xml pelo esquema xsd.");

            bool ok = validadorXML.ValidarXml(@"C:\fgirardi\XML\9999999999999999-nfe.xml", @"c:\fgirardi\XSD\procNFe_v3.10.xsd");

            if (!ok)
                Console.WriteLine("A validação falhou. :(");
            else
                Console.WriteLine("A validação foi realizada com sucesso. :)");

            Console.ReadLine();
        }
    }
}
