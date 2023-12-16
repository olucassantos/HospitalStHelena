using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalStHelena
{
    internal static class Validacao
    {
        public static bool VerificaComprimento(TextBox caixa, int limite, string campo, bool permiteVazio = false)
        {
            if (caixa.Text.Length > limite)
            {
                MessageBox.Show($"O campo {campo} não pode ter mais que {limite} caracteres!");
                caixa.Focus();
                return false;
            }

            // Verifica se pode ficar vazio
            if (!permiteVazio && caixa.Text.Length == 0)
            {
                MessageBox.Show($"O campo {campo} não pode ficar em branco!");
                caixa.Focus();
                return false;
            }
            
            return true;
        }

        public static bool VerificaComprimento(MaskedTextBox caixa, int limite, string campo, bool permiteVazio = true)
        {
            if (caixa.Text.Length > limite)
            {
                MessageBox.Show($"O campo {campo} não pode ter mais que {limite} caracteres!");
                caixa.Focus();
                return false;
            }

            // Verifica se pode ficar vazio
            if (!permiteVazio && caixa.Text.Length == 0)
            {
                MessageBox.Show($"O campo {campo} não pode ficar em branco!");
                caixa.Focus();
                return false;
            }

            return true;
        }
    }
}
