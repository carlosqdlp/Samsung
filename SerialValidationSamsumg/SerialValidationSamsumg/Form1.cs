using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialValidationSamsumg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ocultar();
          
    }

        private void Form1_Load(object sender, EventArgs e)
        {

          
        }  
        //EVENTOS
              
        public void serieMal()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = @"bad.wav";
            player.Play();           
        }
        public void SerieBien()
        {
            lblRespuesta.ForeColor = Color.Green;
            //txtMsg.BackColor = System.Drawing.Color.Green;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = @"good.wav";
            player.Play();
        }
  
        private void btnAceptar_Click(object sender, EventArgs e)
        {           
            if (txtPasword.Text != "")
            {
                txtSamSerial.Focus();
                if (txtPasword.Text == "ABCD")
                {             
                    groupBox1.Enabled = true;
                    txtPasword.Clear();
                    Limpiar();
                    lblRespuesta.Text = "";
                    txtSamSerial.Focus();
                    ocultar();                    
                }
                else
                {
                    txtPasword.Clear();
                    txtSamSerial.Focus();
                    MessageBox.Show("Contraseña erronea ...");
                }

            }
            else
            {
                txtPasword.Clear();
                txtSamSerial.Focus();
                MessageBox.Show("Todos los campos son necesarios");              
            }       
        }
        public void mostrar()
        {         
            txtPasword.Show();
            txtPasword.Focus();
            txtPasword.BackColor = Color.Yellow;
        }
        public void ocultar()
        {
           
            txtPasword.Hide();
            color();
        }
        public void Limpiar()
        {
            txtHpSerial.Clear();
            txtSamSerial.Clear();
          
        }
        public void color()
        {
            this.BackColor = System.Drawing.SystemColors.Control;
        }      
        public void capturaserie()
        {
            Series sSeries = new Series();

            string Samsumg = txtSamSerial.Text.Trim();
            string Hp = txtHpSerial.Text.Trim();

            if ((txtHpSerial.Text != "") && (txtSamSerial.Text != ""))
            {

                if (sSeries.validarCantidadSeries(txtSamSerial.Text, txtHpSerial.Text))
                {
                    lblRespuesta.Text = "ETIQUETA CORRECTA!";
                    txtSamSerial.Focus();
                    SerieBien();
                    Limpiar();
                }
                else
                {                  
                    this.BackColor = Color.Red;
                    lblRespuesta.Text = "ETIQUETA INTERCAMBIADA!!";
                    serieMal();
                    groupBox1.Enabled = false;                
                    mostrar();
                }
            }
            else
            {
                serieMal();
                MessageBox.Show("DEBE INGRESAR SERIES!");
            }
        }
 
        private void txtHpSerial_KeyPress(object sender, KeyPressEventArgs e)
        {       
            if (e.KeyChar == 13)
            {
                if( txtSamSerial.Text.Length == 15 )
                {
                    if (txtHpSerial.Text.Length == 10)
                    {
                        capturaserie();

                    }
                    else
                    {
                        // MessageBox.Show("SERIE HP MAL INGRESADA!");

                        lblRespuesta.ForeColor = Color.Red;
                        lblRespuesta.Text = "SERIE HP MAL INGRESADA!";
                        serieMal();
                        Limpiar();
                        txtSamSerial.Focus();
                    }
                    

                }
                else
                {
                    //MessageBox.Show("SERIE SAMSUMG MAL INGRESADA!.");
                    lblRespuesta.ForeColor = Color.Red;
                    lblRespuesta.Text = "SERIE SAMSUMG MAL INGRESADA!";
                    serieMal();
                    Limpiar();
                    txtSamSerial.Focus();
                }
               
                
            }
        }

        private void txtSamSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtHpSerial.Focus();
            }
        }

        private void txtPasword_KeyPress(object sender, KeyPressEventArgs e)    
        {
            //txtPasword.Clear();     
            string pasword = txtPasword.Text.Trim();

           
            if (e.KeyChar == 13)
            {
               
              if (txtPasword.Text != "")
                {
                    //M3%IC0GCC
                    if ((pasword == "GCC") ||(pasword == "gcc"))
                    {
                        groupBox1.Enabled = true;
                        txtPasword.Clear();
                        Limpiar();
                        lblRespuesta.Text = "";
                        txtSamSerial.Focus();
                        ocultar();
                    }
                    else
                    {
                        txtPasword.Clear();
                        pasword = "";
                        txtPasword.Focus();
                       MessageBox.Show("Contraseña erronea ...");
                    }

                }
             
                else
                {
                    txtPasword.Clear();
                    txtSamSerial.Focus();
                    MessageBox.Show("Todos los campos son necesarios");
                }
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
