using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoThinkLab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            txtNumeroCredito.BackColor = Color.White;
            txtNombre.BackColor = Color.White;
            txtSueldo.BackColor = Color.White;
            string numeroCredito = txtNumeroCredito.Text.Trim();
            try
            {
                int numeroCredito_int = Convert.ToInt32(numeroCredito);

                if (numeroCredito.Length == 0)
                {
                    MessageBox.Show("Cuadro esta vacio");
                    return;
                }
            }
            catch(FormatException ex)
            {
                txtNumeroCredito.BackColor = Color.Red;
                MessageBox.Show(ex.Message);
                return;
            }




            string nombre = txtNombre.Text.Trim();
            if (nombre.Length == 0)
            {
                txtNombre.BackColor = Color.Red;
                MessageBox.Show("Debe ingresar un Nombre");
                return;
            }


            string sueldo = txtSueldo.Text.Trim();
            double sueldo_dou = 0;
            double maximo_solicitud = 0;
            try
            {
                sueldo_dou = Convert.ToDouble(sueldo);
                maximo_solicitud = sueldo_dou * 150 / 100;

                MessageBox.Show(maximo_solicitud.ToString());
            }
            catch(FormatException ex) {
                txtSueldo.BackColor = Color.Red;
                MessageBox.Show(ex.Message);
                return;
            }

            string monto = txtMonto.Text.Trim();
            double monto_dou = 0;
            try
            {
                monto_dou = Convert.ToDouble(monto);
                if( monto_dou > maximo_solicitud )
                {
                    MessageBox.Show("Monto solicitado excede el maximo de 150% del sueldo");
                    return;
                }
                
            }catch (FormatException ex)
            {
                txtMonto.BackColor = Color.Red;
                MessageBox.Show(ex.Message);
                return;
            }

            string cuota = txtCuota.Text.Trim();
            int cuota_int = 0;
            try
            {
                cuota_int = Convert.ToInt32(cuota);
                if(cuota_int < 6)
                {
                    txtCuota.BackColor = Color.Red;
                    MessageBox.Show("Cantidad de cuotas no puede ser menor a 6");
                    return;
                }
            } catch(FormatException ex)
            {
                txtCuota.BackColor = Color.Red;
                MessageBox.Show(ex.Message);
                return;
            }


            lblNumeroCredito.Text = numeroCredito;
            lblNombre.Text = nombre;


            float interes_mensual = 1.85f / 12f;
            MessageBox.Show(interes_mensual.ToString());

            double cuota_mensual = monto_dou * interes_mensual ;

            lblCuotaMensual.Text = cuota_mensual.ToString();

            lblMontoFinal.Text = ((cuota_mensual * cuota_int) + monto_dou).ToString(); 

            MessageBox.Show(cuota_mensual.ToString());
        }
    }
}
