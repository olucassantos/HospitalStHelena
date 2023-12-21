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
    public partial class frmListaFuncionarios : Form
    {
        private MySqlDataAdapter adaptador;
        private DataTable dataTable;

        // Executa quando o formulário é instanciado
        public frmListaFuncionarios()
        {
            InitializeComponent();
        }

        private void btnAdicionarFuncionario_Click(object sender, EventArgs e)
        {
            frmFuncionarios funcionarios = new frmFuncionarios();
            funcionarios.ShowDialog();
        }

        // Acontece quando o formulário termina de carregar
        private void frmListaFuncionarios_Load(object sender, EventArgs e)
        {
            // Conectamos ao banco de dados
            ConexaoDB conexaoDB = new ConexaoDB();

            //string sql = "SELECT funcionarios.id, nome, cpf, email, titulo Cargo " +
            //    "FROM funcionarios join cargos on (funcionarios.cargo_id = cargos.id)";

            string sql = "SELECT * FROM funcionarios";

            // Cria um comando para o mysql
            var comando = new MySqlCommand(sql, conexaoDB.conexao);

            // Adapta o resultado da consulta ao banco
            adaptador = new MySqlDataAdapter(comando);

            // Cria uma tabela de dados
            dataTable = new DataTable();

            // Adiciona o resultado a tabela de dados
            adaptador.Fill(dataTable);

            // Cria um BindingSource para o DataGridView
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            // Associa o DataSource com o bindingSource
            dataFuncionarios.DataSource = bindingSource;
            barraNavegacao.BindingSource = bindingSource;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Classe para criar comandos para o MySQL
            MySqlCommandBuilder construtoraComandos = new MySqlCommandBuilder(adaptador);

            // Executa um comando para atualizar a tabela
            adaptador.Update(dataTable);
        }
    }
}
