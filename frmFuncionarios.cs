using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalStHelena
{
    public partial class frmFuncionarios : Form
    {
        ConexaoDB conexao;
        public frmFuncionarios()
        {
            InitializeComponent();
            conexao = new ConexaoDB();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "Deseja cancelar o cadastro?", 
                "Cancelando cadastro", 
                MessageBoxButtons.YesNo
            );

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            DateTime data_nascimento = datDataNascimento.Value;
            // Faz um casting do item selecionado para a classe de Cargo
            Cargo cargo = (Cargo)cmbCargo.SelectedItem;

            // Validações
            Validacao.VerificaComprimento(txtNome, 255, "nome", false);
            Validacao.VerificaComprimento(txtCpf, 11, "cpf", false);
            Validacao.VerificaComprimento(txtEmail, 255, "email", false);
            Validacao.VerificaComprimento(txtSenha, 10, "senha", false);

            // Valida que precisa ser maior de 18 anos
            if (CalculaIdade(data_nascimento) < 18)
            {
                MessageBox.Show("A data de nascimento não pode ser menor que 18 anos");
            }

            var parametros = new Dictionary<string, object> {
                { "nome", nome },
                { "cpf", cpf },
                { "email", email },
                { "data_nascimento", data_nascimento.ToString("yyyy-MM-dd") },
                { "senha", senha },
                { "cargo_id", cargo.id },
            };
            
            // Tenta inserir no banco
            bool resultado = conexao.Inserir("funcionarios", parametros);

            // Verifica se deu certo
            if (resultado)
            {
                MessageBox.Show("Salvo com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao salvar");
            }
        }

        private int CalculaIdade(DateTime data_nascimento)
        {
            DateTime data_atual = DateTime.Now;

            int idade = data_atual.Year - data_nascimento.Year;

            if (data_atual.Month < data_nascimento.Month ||
                    (data_atual.Month == data_nascimento.Month && data_atual.Day < data_nascimento.Day))
                idade--;

            return idade;
        }
    }
}
