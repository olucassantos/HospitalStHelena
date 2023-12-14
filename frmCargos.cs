using MySqlConnector;
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
    public partial class frmCargos : Form
    {
        ConexaoDB conexaoDb;

        public frmCargos()
        {
            InitializeComponent();

            // Cria uma nova instancia da nossa classe de conexão
            conexaoDb = new ConexaoDB();
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

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            string descricao = txtDescricao.Text;

            if (titulo.Length > 255)
            {
                MessageBox.Show("O comprimento máximo do titulo é 255 caracteres");
                return;
            }

            if (titulo == "")
            {
                MessageBox.Show("O titulo não pode ficar em branco");
                return;
            }

            if (descricao.Length > 255)
            {
                MessageBox.Show("O comprimento máximo do descrição é 255 caracteres");
                return;
            }

            // Cria um dicionário com os parametros.
            var parametros = new Dictionary<string, object> {
                { "titulo", titulo },
                { "descricao", descricao }
            };

            // Executa no banco e pega o resultado
            bool resultado = conexaoDb.Inserir("cargos", parametros);

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
    }
}
