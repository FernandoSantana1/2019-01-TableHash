using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableHash
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public Hashtable Users = new Hashtable();
        private void gerarUsuarios()
        {
            string chave;
            Users.Clear(); listBox1.Items.Clear();
            Users.Add( Dados.Chave, ("Nome: " + Dados.Nome,"Sexo: " +  Dados.Sexo, "Telefone: " + Dados.Tel, "CEP: " + Dados.Cep, "Email: " + Dados.Email, "Nascimento: " + Dados.Data, "CPF: " + Dados.Cpf, "Senha: " + Dados.Senha)); //adiciona na lista hash
            listBox1.Items.Add("Chave: " + Dados.Chave + " | Usuário: " + Users[Dados.Chave]);
            int tel; int cep; int cpf; Random rnd = new Random(); int cpf2; int dia; int mes; int ano; int senha;
            for (int i = 0; i < 10; i++)
            {
                //Gera os dados aleatórios (apenas para simular usuários cadastrados)
                tel = rnd.Next(1111111, 9999999);
                cep = rnd.Next(11111111, 99999999);
                cpf = rnd.Next(11111, 99999);
                cpf2 = rnd.Next(111111, 999999);
                dia = rnd.Next(1, 30);
                mes = rnd.Next(1, 12);
                ano = rnd.Next(1960, 2001);
                senha = rnd.Next(1111, 99999999);
                chave = Convert.ToString(cep).Substring(Convert.ToString(cep).Length - 2, 2) + Convert.ToString(ano).Substring(Convert.ToString(ano).Length - 2, 2) + Convert.ToString(cpf).Substring(Convert.ToString(cpf).Length - 2, 2); //pega os ultimos 2 digitos de cada dado
                Users.Add(chave, ("Nome: " + "Nome do Usuário", "Sexo: " + "Masculino","Telefone: " + "(41)9" + tel, "CEP: " + cep, "Email: " + "usuario@gmail.com", "Nacimento: " + Convert.ToString(dia) + "/" + Convert.ToString(mes) + "/" + Convert.ToString(ano), "CPF: " + Convert.ToString(cpf) + Convert.ToString(cpf2), "Senha: " + senha));
                listBox1.Items.Add("Chave: " + chave + " | Usuário: " + Users[chave]);
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            lblNome.Text = "Nome: ";
            lblSexo.Text = "Sexo: ";
            lblTEl.Text = "Tel: ";
            lblCep.Text = "CEP: ";
            lblEmail.Text = "Email: ";
            lblData.Text = "Nascimento: "; 
            lblCPF.Text = "CPF: ";
            string chave;string senha;
            chave = textChave.Text;
            senha = textSenha.Text;
           
            if (chave == Dados.Chave & senha == Dados.Senha)
            {
                gerarUsuarios();
                lblNome.Text = "Nome: " +  Dados.Nome;
                lblSexo.Text = "Sexo: " + Dados.Sexo;
                lblTEl.Text = "Tel: " + Dados.Tel;
                lblCep.Text = "CEP: " + Dados.Cep;
                lblEmail.Text = "Email: " + Dados.Email;
                lblData.Text = "Nascimento: " + Dados.Data;
                lblCPF.Text = "CPF: " + Dados.Cpf;
                btnProcurar.Enabled = true;
                textProcChave.Enabled = true;
                label4.Enabled = true;
            }
            else
            {
                Users.Clear(); listBox1.Items.Clear();textProcChave.Clear(); label4.Enabled = false; textProcChave.Enabled = false; btnProcurar.Enabled = false;
                label2.ForeColor = Color.Red;
                label2.Text = "Chave de acesso ou senha incorreta!";
            }
        }

        private void BtnProcurar_Click(object sender, EventArgs e)
        {
            ProcurarChave("Chave: " + textProcChave.Text);
            void ProcurarChave(string ChaveProcurada)
            {
                //Verificar se a string não é vazia
                if (!string.IsNullOrEmpty(ChaveProcurada))
                {
                    // Encontra o item e armazena o index dele
                    int index = listBox1.FindString(ChaveProcurada);
                    // Verifica se o index retornado é valido e seleciona o item na combobox
                    if (index != -1)
                    {
                        listBox1.SetSelected(index, true);
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado! Certifique-se de que a chave inserida está correta e tente novamente!", "Usuário não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
