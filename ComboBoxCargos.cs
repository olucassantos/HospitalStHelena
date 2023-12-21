using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalStHelena.Modelos;

namespace HospitalStHelena
{
    internal class ComboBoxCargos : ComboBox
    {
        ConexaoDB conexao;
        public ComboBoxCargos() 
        {
            conexao = new ConexaoDB();

            CarregaItens();
        }

        private void CarregaItens()
        {
            List<Cargo> lista = conexao.SelecionaTudo("cargos");

            foreach (Cargo cargo in lista)
            {
                this.Items.Add(cargo);
            }
        }

    }
}
