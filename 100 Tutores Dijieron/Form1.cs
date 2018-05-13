using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _100_Tutores_Dijieron
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            allvalue = 0;
            Application.CurrentCulture=new System.Globalization.CultureInfo("es");
            rondas = new List<Rondas>();

            rondas.Add(new Rondas("ronda1"));
            rondas.Add(new Rondas("ronda2"));
            rondas.Add(new Rondas("ronda3"));
            rondas.Add(new Rondas("ronda4"));
            rondas.Add(new Rondas("ronda5"));
            rondas.Add(new Rondas("ronda6"));
            rondas.Add(new Rondas("ronda7"));
            rondas.Add(new Rondas("ronda8"));
        }

        public static int allvalue;
        public static int team1;
        public static int team2;
        int intervalo_equis = 0;
        int numero_equis = 0;
        public static int value1;
        public static int value2;
        public static int value3;
        public static int value4;
        public static int value5;
        public static int ron = -1;
        static List<Rondas> rondas;
        Sonido sonido = new Sonido();

        public void cargar_ronda(int i)
        {
            sonido.reproducir("canciones/sonidos_round_100_mexicanos.wav");
            reset();
            ronda.Text = "Ronda " + (i + 1);
            pregunta.Text = rondas[i].pregunta.texto;
            if (ron == 5)
                MessageBox.Show("Cargando la \'Ronda " + (i + 1) + "\'\r\nPUNTOS AL DOBLE", "Ronda", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else if (ron == 6 || ron == 7)
                MessageBox.Show("Cargando la \'Ronda " + (i + 1) + "\'\r\nPUNTOS AL TRIPLE", "Ronda", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show("Cargando la \'Ronda " + (i + 1) + "\'", "Ronda", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void reset()
        {
            value1 = 0;
            value2 = 0;
            value3 = 0;
            value4 = 0;
            value5 = 0;
            resp1.Text = ". . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .";
            resp2.Text = ". . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .";
            resp3.Text = ". . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .";
            resp4.Text = ". . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .";
            resp5.Text = ". . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .";
            marker1.Text = "0";
            marker2.Text = "0";
            marker3.Text = "0";
            marker4.Text = "0";
            marker5.Text = "0";
            general.Text = "0";
            allvalue = 0;
            team1 = 0;
            team2 = 0;
            numero_equis = 0;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
        }

        private void prev_Click(object sender, EventArgs e)
        {
            if (ron != -1)
            {
                if (ron == 0)
                {
                    MessageBox.Show("Ya no puedes regresar mas ...", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (ron >= 1)
                {
                    ron = ron - 1;
                    cargar_ronda(ron);
                }
            }
            else
            {
                MessageBox.Show("No se han iniciado las rondas, debes presionar el boton \'i\' para iniciar !", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (ron != -1)
            {
                if (ron == 7)
                {
                    MessageBox.Show("Ya no puedes ir mas adelante ...", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (ron < 7)
                {
                    ron = ron + 1;
                    cargar_ronda(ron);
                }
            }
            else
            {
                MessageBox.Show("No se han iniciado las rondas, debes presionar el boton \'i\' para iniciar !", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void iniciar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Van a empezar las 8 rondas para moverte entre las diferentes rondas debes presionar los botones \'ronda anterior\' y \'ronda siguiente\'", "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ron = 0;
            cargar_ronda(ron);
        }

        private void resetear_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sonido.reproducir("canciones/entrada100_Mexicanos_Dijieron.wav");
            iniciar.Select();
        }

        private void toteam1_Click(object sender, EventArgs e)
        {
            markerteam1.Text = "" + (int.Parse(markerteam1.Text) + int.Parse(general.Text));
            sonido.reproducir("canciones/sonidos_ganador_100_mexicanos.wav");
            general.Text = "" + 0;
            allvalue = 0;
        }

        private void toteam2_Click(object sender, EventArgs e)
        {
            markerteam2.Text = "" + (int.Parse(markerteam2.Text) + int.Parse(general.Text));
            sonido.reproducir("canciones/sonidos_ganador_100_mexicanos.wav");
            general.Text = "" + 0;
            allvalue = 0;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (ron != -1)
            {
                resp1.Text = rondas[ron].pregunta.respuestas[0].texto;
                if (ron == 5)
                    value1 = (rondas[ron].pregunta.respuestas[0].puntaje)*2;
                else if (ron == 6 || ron == 7)
                    value1 = (rondas[ron].pregunta.respuestas[0].puntaje)*3;
                else
                    value1 = rondas[ron].pregunta.respuestas[0].puntaje;
                sonido.reproducir("canciones/sonido_acierto_100_mexicanos.wav");
                marker1.Text = "" + value1;
                allvalue += value1;
                general.Text = "" + allvalue;
                value1 = 0;
                btn1.Enabled = false;
            }
            else
            {
                MessageBox.Show("No has iniciado las rondas, para empezar debes presionar el boton \'i\' !", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (ron != -1)
            {
                resp2.Text = rondas[ron].pregunta.respuestas[1].texto;
                if (ron == 5)
                    value2 = (rondas[ron].pregunta.respuestas[1].puntaje) * 2;
                else if (ron == 6 || ron == 7)
                    value2 = (rondas[ron].pregunta.respuestas[1].puntaje) * 3;
                else
                    value2 = rondas[ron].pregunta.respuestas[1].puntaje;
                sonido.reproducir("canciones/sonido_acierto_100_mexicanos.wav");
                marker2.Text = "" + value2;
                allvalue += value2;
                general.Text = "" + allvalue;
                value2 = 0;
                btn2.Enabled = false;
            }
            else
            {
                MessageBox.Show("No has iniciado las rondas, para empezar debes presionar el boton \'i\' !", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (ron != -1)
            {
                resp3.Text = rondas[ron].pregunta.respuestas[2].texto;
                if (ron == 5)
                    value3 = (rondas[ron].pregunta.respuestas[2].puntaje) * 2;
                else if (ron == 6 || ron == 7)
                    value3 = (rondas[ron].pregunta.respuestas[2].puntaje) * 3;
                else
                    value3 = rondas[ron].pregunta.respuestas[2].puntaje;
                sonido.reproducir("canciones/sonido_acierto_100_mexicanos.wav");
                marker3.Text = "" + value3;
                allvalue += value3;
                general.Text = "" + allvalue;
                value3 = 0;
                btn3.Enabled = false;
            }
            else
            {
                MessageBox.Show("No has iniciado las rondas, para empezar debes presionar el boton \'i\' !", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (ron != -1)
            {
                resp4.Text = rondas[ron].pregunta.respuestas[3].texto;
                if (ron == 5)
                    value4 = (rondas[ron].pregunta.respuestas[3].puntaje) * 2;
                else if (ron == 6 || ron == 7)
                    value4 = (rondas[ron].pregunta.respuestas[3].puntaje) * 3;
                else
                    value4 = rondas[ron].pregunta.respuestas[3].puntaje;
                sonido.reproducir("canciones/sonido_acierto_100_mexicanos.wav");
                marker4.Text = "" + value4;
                allvalue += value4;
                general.Text = "" + allvalue;
                value4 = 0;
                btn4.Enabled = false;
            }
            else
            {
                MessageBox.Show("No has iniciado las rondas, para empezar debes presionar el boton \'i\' !", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (ron != -1)
            {
                resp5.Text = rondas[ron].pregunta.respuestas[4].texto;
                if (ron == 5)
                    value5 = (rondas[ron].pregunta.respuestas[4].puntaje) * 2;
                else if (ron == 6 || ron == 7)
                    value5 = (rondas[ron].pregunta.respuestas[4].puntaje) * 3;
                else
                    value5 = rondas[ron].pregunta.respuestas[4].puntaje;
                sonido.reproducir("canciones/sonido_acierto_100_mexicanos.wav");
                marker5.Text = "" + value5;
                allvalue += value5;
                general.Text = "" + allvalue;
                value5 = 0;
                btn5.Enabled = false;
            }
            else
            {
                MessageBox.Show("No has iniciado las rondas, para empezar debes presionar el boton \'i\' !", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fail_Click(object sender, EventArgs e)
        {
            if (numero_equis >= 0 && numero_equis <= 3)
            {
                numero_equis++;
                if (numero_equis == 1)
                {
                    markerfail.Text = "X";
                    sonido.reproducir("canciones/sonido_striker_100_mexicanos.wav");
                    timer1.Enabled = true;
                }
                else if (numero_equis == 2)
                {
                    markerfail.Text = "XX";
                    sonido.reproducir("canciones/sonido_striker_100_mexicanos.wav");
                    timer1.Enabled = true;
                }
                else if (numero_equis == 3)
                {
                    markerfail.Text = "XXX";
                    sonido.reproducir("canciones/sonido_striker_100_mexicanos.wav");
                    timer1.Enabled = true;
                }
            }
            else 
            {
                markerfail.Text = "XXX";
                sonido.reproducir("canciones/sonido_striker_100_mexicanos.wav");
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            intervalo_equis++;
            if (intervalo_equis > 10)
            {
                markerfail.Text = "";
                timer1.Enabled = false;
                intervalo_equis = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            markerfail.Text = "X";
            timer1.Enabled = true;
            sonido.reproducir("canciones/sonido_striker_100_mexicanos.wav");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCreditos frm = new frmCreditos();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
