using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableHash
{
    class Dados
    {
        //(nome, sexo, tel, cep, email, data, cpf, senha));
        private static string CHAVE;
        private static string NOME;
        private static string SEXO;
        private static string TEL;
        private static string CEP;
        private static string EMAIL;
        private static string DATA;
        private static string CPF;
        private static string SENHA;
        public static string Chave { get { return CHAVE; } set { CHAVE = value; } }
        public static string Nome { get { return NOME; } set { NOME = value; } }
        public static string Sexo { get { return SEXO; } set { SEXO = value; } }
        public static string Tel { get { return TEL; } set { TEL = value; } }
        public static string Cep { get { return CEP; } set { CEP = value; } }
        public static string Email { get { return EMAIL; } set { EMAIL = value; } }
        public static string Data { get { return DATA; } set { DATA = value; } }
        public static string Cpf { get { return CPF; } set { CPF = value; } }
        public static string Senha { get { return SENHA; } set { SENHA = value; } }
    }
}
