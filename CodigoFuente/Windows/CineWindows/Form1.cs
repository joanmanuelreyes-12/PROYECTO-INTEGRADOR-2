using System;
using System.Drawing;
using System.Windows.Forms;

namespace CineWindows
{
    public partial class Form1 : Form
    {
        private int[,] asientos = new int[4, 4];

        private Button? asientoSeleccionado;
        private int filaSeleccionada = -1;
        private int columnaSeleccionada = -1;

        public Form1()
        {
            InitializeComponent();

            CrearAsientos();
            ActualizarEstadisticas();

            btnReservar.Click += (s, e) => CambiarEstado(1);
            btnLiberar.Click += (s, e) => CambiarEstado(0);
            btnDisponibilidad.Click += (s, e) => ConsultarAsiento();
            btnEstadisticas.Click += (s, e) => MostrarEstadisticas();
        }

        private void CrearAsientos()
        {
            int ancho = 100;
            int alto = 45;
            int espacioX = 20;
            int espacioY = 12;

            int inicioX = (pnlAsientos.Width - 460) / 2;
            int inicioY = 20;

            for (int fila = 0; fila < 4; fila++)
            {
                for (int columna = 0; columna < 4; columna++)
                {
                    Button boton = new Button();

                    boton.Text = $"{(char)('A' + fila)}{columna + 1}";
                    boton.Size = new Size(ancho, alto);

                    boton.Location = new Point(
                        inicioX + columna * (ancho + espacioX),
                        inicioY + fila * (alto + espacioY)
                    );

                    boton.BackColor = Color.FromArgb(33, 134, 116);
                    boton.ForeColor = Color.White;
                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderSize = 0;
                    boton.Font = new Font("Segoe UI", 11, FontStyle.Bold);

                    boton.Click += SeleccionarAsiento;

                    pnlAsientos.Controls.Add(boton);
                }
            }
        }

        private void SeleccionarAsiento(object? sender, EventArgs e)
        {
            if (sender is not Button boton)
                return;

            if (asientoSeleccionado != null)
                asientoSeleccionado.FlatAppearance.BorderSize = 0;

            asientoSeleccionado = boton;

            filaSeleccionada = boton.Text[0] - 'A';
            columnaSeleccionada = boton.Text[1] - '1';

            boton.FlatAppearance.BorderSize = 3;
            boton.FlatAppearance.BorderColor = Color.Gold;
        }

        private void CambiarEstado(int nuevoEstado)
        {
            if (asientoSeleccionado == null)
            {
                MessageBox.Show("Primero selecciona un asiento.");
                return;
            }

            if (asientos[filaSeleccionada, columnaSeleccionada] == nuevoEstado)
            {
                string mensaje = nuevoEstado == 1
                    ? "Este asiento ya está ocupado."
                    : "Este asiento ya está disponible.";

                MessageBox.Show(mensaje);
                return;
            }

            asientos[filaSeleccionada, columnaSeleccionada] = nuevoEstado;

            asientoSeleccionado.BackColor = nuevoEstado == 1
                ? Color.Red
                : Color.FromArgb(33, 134, 116);

            ActualizarEstadisticas();
        }

        private void ConsultarAsiento()
        {
            if (asientoSeleccionado == null)
            {
                MessageBox.Show("Primero selecciona un asiento.");
                return;
            }

            string estado = asientos[filaSeleccionada, columnaSeleccionada] == 0
                ? "Disponible"
                : "Ocupado";

            MessageBox.Show(
                $"Asiento {asientoSeleccionado.Text}: {estado}",
                "Consulta de disponibilidad"
            );
        }

        private void ActualizarEstadisticas()
        {
            int ocupados = 0;

            for (int fila = 0; fila < 4; fila++)
            {
                for (int columna = 0; columna < 4; columna++)
                {
                    if (asientos[fila, columna] == 1)
                        ocupados++;
                }
            }

            int disponibles = 16 - ocupados;
            double porcentaje = ocupados * 100.0 / 16;

            lblDisponibles.Text = $"Disponibles: {disponibles}";
            lblOcupados.Text = $"Ocupados: {ocupados}";
            lblPorcentaje.Text = $"Ocupación: {porcentaje:0.##}%";
        }

        private void MostrarEstadisticas()
        {
            ActualizarEstadisticas();

            MessageBox.Show(
                $"{lblDisponibles.Text}\n" +
                $"{lblOcupados.Text}\n" +
                $"{lblPorcentaje.Text}",
                "Estadísticas de la sala"
            );
        }
    }
}
