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

            // Cria uma nova instancia de comandos do Mysql
            using (var comando = new MySqlCommand())
            {
                // Define em qual conexão vai ser executado o comando
                comando.Connection = conexaoDb.conexao;
                // Cria a SQL que vai ser executada;
                comando.CommandText = "INSERT INTO cargos (titulo, descricao) VALUES (@titulo, @descricao)";

                // Adiciona os valores aos parametros;
                comando.Parameters.AddWithValue("titulo", titulo);
                comando.Parameters.AddWithValue("descricao", descricao);

                // Executa o comando
                await comando.ExecuteNonQueryAsync();
            }
        }
    }
}
