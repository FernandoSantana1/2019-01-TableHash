using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableHash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }
        string chave;
        public Hashtable Users = new Hashtable();
        private void SalvarDados(string nome, string sexo, string tel, string cep, string email, string data, string cpf, string senha)
        {
            if (chave != textChave.Text)
            {
                chave = cep.Substring(cep.Length - 2, 2) + data.Substring(data.Length - 2, 2) + cpf.Substring(cpf.Length - 2, 2); //pega os ultimos 2 digitos de cada dado
                Users.Add(chave, (nome, sexo, tel, cep, email, data, cpf, senha));//passar os dados para a hash table///////
                foreach (DictionaryEntry User in Users)
                {
                    Console.WriteLine($"Nome: {User.Value}");
                    Console.WriteLine($"Key: {User.Key}");
                }
                Console.WriteLine("#################################");
            }
            else
            {
                MessageBox.Show("Usuário já cadastrado, insira os dados corretamente e tente novamente!", "Usuário já cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string senha1;string TEL;string CEP;string SEXO; string EMAIL;
            string senha2;string CPF;string DATA; string NOME;
            senha1 = textSenha.Text;
            senha2 = textConfirma.Text;
            Regex regex = new Regex("[^\\d]");
            NOME = textNome.Text;
            TEL = regex.Replace(maskedTel.Text, ""); //remove tudo que nao for numeros
            CPF = regex.Replace(maskedCPF.Text,"");
            CEP = regex.Replace(maskedCEP.Text,"");
            DATA = regex.Replace(maskeData.Text, "");
            EMAIL = textEmail.Text;
            SEXO = comboSexo.Text;

            if (NOME != "" & senha1 == senha2 & TEL != "" & CPF != "" & CEP != "" & DATA != "" & EMAIL != "" & SEXO != "")   
            {
                SalvarDados(NOME, SEXO, TEL, CEP, EMAIL, DATA, CPF, senha1);
                button2.Enabled = true;
                labelUser.ForeColor = Color.Green;
                labelUser.Text = "Usuário cadastrado com sucesso! " + Environment.NewLine + "Sua chave de acesso é: " + chave;
                textChave.Text = chave;
                Dados.Chave = chave; Dados.Nome = NOME; Dados.Tel = TEL; Dados.Cpf = CPF; Dados.Cep = CEP; Dados.Data = DATA; Dados.Email = EMAIL; Dados.Sexo = SEXO; Dados.Senha = senha1;
            }
            if (NOME == "" || TEL == "" || CPF == "" || CEP == "" || DATA == "" || EMAIL == "" || SEXO == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos corretamente!", "Campo(s) em branco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (senha1 != senha2)
            {
                MessageBox.Show("As duas senhas devem ser iguais!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Login form2 = new Login();
            form2.Closed += (s, args) => Close();
            form2.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            labelUser.Text = "Chave de acesso copiada para área de transferência!";
            Clipboard.SetText(textChave.Text);
        }
    }
}
