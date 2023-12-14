using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalStHelena
{
    internal class ConexaoDB
    {
        MySqlConnectionStringBuilder builder;
        public MySqlConnection conexao;

        public ConexaoDB()
        {
            builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "12345",
                Database = "hospital",
                Port = 3306
            };

            // Executa a conexão com o banco de dados.
            conectar();
        }

        private async void conectar()
        {
            // Passa os dados de conexão para o MysqlConnector
            conexao = new MySqlConnection(builder.ConnectionString);

            // Faz a conexão com o banco de dados.
            await conexao.OpenAsync();
        }

        public bool Inserir()
        {


            return false;
        }
    }
}
