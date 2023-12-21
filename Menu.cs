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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void cargosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Cria uma instancia do formulário de cargos
            frmCargos cargos = new frmCargos();

            // Mostra o formulário de cargos
            cargos.ShowDialog();
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaFuncionarios listaFuncionarios = new frmListaFuncionarios();
            listaFuncionarios.ShowDialog();
        }
    }
}
