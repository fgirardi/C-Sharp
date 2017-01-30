using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploLambda
{   /*Desenvolvido por: Fabiano Girardi.
     Objetivo: Exemplificar o uso de Expressões Lambda*/
    class Pessoa
    {
        public String Nome { get; set; }
        public int Idade { get; set; }
        public String Cidade { get; set; }
        public String Sexo { get; set; }

        public Pessoa(String _Nome, int _Idade,
         String _Cidade, String _Sexo)
        {
            Nome = _Nome;
            Idade = _Idade;
            Cidade = _Cidade;
            Sexo = _Sexo;
        }

        public override String ToString()
        {
            return "Nome: " + Nome + " Idade: " +
             Idade.ToString() + " Cidade: " + Cidade + " Sexo: " + Sexo;
        }

    }

    class lPessoa : List<Pessoa>
    {
        public lPessoa()
        {
            this.Add(new Pessoa("Carlos Mazico", 25, "Blumenau", "M"));
            this.Add(new Pessoa("Jose Beleia", 20, "Itajai", "M"));
            this.Add(new Pessoa("Ana Paula Traz", 17, "CAMPINAS", "M"));
            this.Add(new Pessoa("Fabiano Girardi", 39, "Gaspar", "M"));
            this.Add(new Pessoa("Guilherme Girardi", 45, "Londrina", "M"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            lPessoa _lPessoa = new lPessoa();

            foreach (var item in _lPessoa.Where
             (p => p.Nome.StartsWith("G") && p.Idade >= 10))
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}
