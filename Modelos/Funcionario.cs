using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalStHelena.Modelos
{
    internal class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data_nascimento { get; set; }
        public string Cpf {  get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Cargo_id { get; set; }
    }
}
