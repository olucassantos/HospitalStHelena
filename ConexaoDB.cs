using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalStHelena.Modelos;

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

        private void conectar()
        {
            // Passa os dados de conexão para o MysqlConnector
            conexao = new MySqlConnection(builder.ConnectionString);

            // Faz a conexão com o banco de dados.
            conexao.Open();
        }

        public bool Inserir(string tabela, Dictionary<string, object> parametros)
        {
            using (var comando = new MySqlCommand())
            {
                // Define em qual conexão vai ser executado o comando
                comando.Connection = this.conexao;

                // Pega cada um dos parametros recebidos e adiciona numa string, separados por virgula.
                string camposTabela = string.Join(", ", parametros.Keys);

                // Cria uma lista com as chaves dos parametros começando com @
                IEnumerable<string> parametrosString = parametros.Keys.Select(chave => "@" + chave);
                string chavesComArroba = string.Join(", ", parametrosString);

                // Cria a SQL que vai ser executada;
                comando.CommandText = $"INSERT INTO {tabela} ({camposTabela}) VALUES ({chavesComArroba})";

                // Pega cada um dos parametros recebidos e adiciona como parametro.
                foreach (var key in parametros.Keys)
                {
                    comando.Parameters.AddWithValue(key, parametros[key]);
                }

                try
                {
                    // Executa o comando
                    int linhasAfetadas = comando.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }

            }
        }

        /*
         Função que retorna todos os dados de uma tabela
         */
        public List<Cargo> SelecionaTudo(string tabela)
        {
            string sql = $"SELECT * FROM {tabela}";

            // Cria uma lista de cargos
            List<Cargo> lista = new List<Cargo>();

            using (var comando = new MySqlCommand())
            {
                // Define em qual conexão vai ser executado o comando
                comando.Connection = this.conexao;

                // Adiciona o comando SQL
                comando.CommandText = sql;

                // Executa o comando do SQL e prepara um leitor (reader)
                using (var leitor = comando.ExecuteReader())
                {
                    // Verifica se tem resultados
                    if (leitor.HasRows)
                    {
                        // Passa linha por linha do resultado
                        while (leitor.Read())
                        {
                            int id = leitor.GetInt32("id");
                            string titulo = leitor.GetString("titulo");
                            string descricao = leitor.GetString("descricao");

                            lista.Add(new Cargo { Id = id, Titulo = titulo, Descricao = descricao });
                        }
                    }
                }

                return lista;
            }
        }

    }
}
