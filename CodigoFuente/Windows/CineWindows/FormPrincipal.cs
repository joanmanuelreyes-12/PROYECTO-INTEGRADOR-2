using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoIntegrador2
{
    public class FormPrincipal : Form
    {
        private readonly int[,] asientos = new int[4, 5];
        private readonly Button[,] botonesAsientos = new Button[4, 5];

        private Panel pnlAsientos;
        private Button btnReservar, btnLiberar, btnDisponibilidad, btnEstadisticas, btnConsultarAsiento;
        private Label lblOcupados, lblDisponibles, lblPorcentaje;

        public FormPrincipal()
        {
            InicializarInterfaz();
            CrearAsientos();
            ActualizarInformacion();
        }

        private void InicializarInterfaz()
        {
            Text = "Sistema de Administración de Asientos de Cine";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(900, 600);

            Controls.Add(new Label {
                Text = "SISTEMA DE ADMINISTRACIÓN DE ASIENTOS DE CINE",
                Font = new Font("Arial", 18, FontStyle.Bold),
                AutoSize = true, Location = new Point(170, 20)
            });

            Controls.Add(new Label {
                Text = "PANTALLA", TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(360, 35), Location = new Point(270, 65)
            });

            pnlAsientos = new Panel {
                Name = "pnlAsientos", BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(470, 255), Location = new Point(215, 115)
            };
            Controls.Add(pnlAsientos);

            btnReservar = CrearBoton("Reservar", 40, 410, 100);
            btnLiberar = CrearBoton("Liberar", 150, 410, 100);
            btnDisponibilidad = CrearBoton("Consultar disponibilidad", 260, 410, 180);
            btnEstadisticas = CrearBoton("Estadísticas", 450, 410, 130);
            btnConsultarAsiento = CrearBoton("Consultar asiento", 590, 410, 150);

            btnReservar.Click += btnReservar_Click;
            btnLiberar.Click += btnLiberar_Click;
            btnDisponibilidad.Click += btnDisponibilidad_Click;
            btnEstadisticas.Click += btnEstadisticas_Click;
            btnConsultarAsiento.Click += btnConsultarAsiento_Click;

            lblOcupados = CrearEtiqueta("Ocupados: 0", 160, 500);
            lblDisponibles = CrearEtiqueta("Disponibles: 20", 350, 500);
            lblPorcentaje = CrearEtiqueta("Ocupación: 0.00%", 550, 500);

            Controls.AddRange(new Control[] {
                btnReservar, btnLiberar, btnDisponibilidad, btnEstadisticas,
                btnConsultarAsiento, lblOcupados, lblDisponibles, lblPorcentaje
            });
        }

        private Button CrearBoton(string texto, int x, int y, int ancho)
        {
            return new Button {
                Text = texto, Size = new Size(ancho, 40),
                Location = new Point(x, y),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
        }

        private Label CrearEtiqueta(string texto, int x, int y)
        {
            return new Label {
                Text = texto, AutoSize = true,
                Location = new Point(x, y),
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
        }

        private void CrearAsientos()
        {
            for (int fila = 0; fila < 4; fila++)
            {
                for (int columna = 0; columna < 5; columna++)
                {
                    Button boton = new Button {
                        Width = 80, Height = 50,
                        Text = $"A{fila + 1}{columna + 1}",
                        Left = 15 + columna * 90,
                        Top = 10 + fila * 58,
                        BackColor = Color.Green,
                        ForeColor = Color.White,
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };

                    int f = fila, c = columna;
                    boton.Click += (sender, e) => CambiarEstadoAsiento(f, c);
                    botonesAsientos[fila, columna] = boton;
                    pnlAsientos.Controls.Add(boton);
                }
            }
        }

        private void CambiarEstadoAsiento(int fila, int columna)
        {
            if (asientos[fila, columna] == 0)
            {
                asientos[fila, columna] = 1;
                botonesAsientos[fila, columna].BackColor = Color.Red;
            }
            else
            {
                asientos[fila, columna] = 0;
                botonesAsientos[fila, columna].BackColor = Color.Green;
            }
            ActualizarInformacion();
        }

        private int ContarOcupados()
        {
            int cantidad = 0;
            for (int fila = 0; fila < 4; fila++)
                for (int columna = 0; columna < 5; columna++)
                    if (asientos[fila, columna] == 1) cantidad++;
            return cantidad;
        }

        private int ContarDisponibles()
        {
            int cantidad = 0;
            for (int fila = 0; fila < 4; fila++)
                for (int columna = 0; columna < 5; columna++)
                    if (asientos[fila, columna] == 0) cantidad++;
            return cantidad;
        }

        private void ActualizarInformacion()
        {
            int total = asientos.GetLength(0) * asientos.GetLength(1);
            int ocupados = ContarOcupados();
            int disponibles = total - ocupados;
            double porcentaje = (double)ocupados / total * 100;

            lblOcupados.Text = $"Ocupados: {ocupados}";
            lblDisponibles.Text = $"Disponibles: {disponibles}";
            lblPorcentaje.Text = $"Ocupación: {porcentaje:0.00}%";
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Haz clic sobre un asiento disponible para reservarlo.",
                "Reservar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Haz clic sobre un asiento ocupado para liberarlo.",
                "Liberar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDisponibilidad_Click(object sender, EventArgs e)
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine($"Asientos disponibles: {ContarDisponibles()}");
            mensaje.AppendLine($"Asientos ocupados: {ContarOcupados()}");
            mensaje.AppendLine();
            mensaje.AppendLine("Asientos disponibles:");

            for (int fila = 0; fila < 4; fila++)
                for (int columna = 0; columna < 5; columna++)
                    if (asientos[fila, columna] == 0)
                        mensaje.Append($"A{fila + 1}{columna + 1}  ");

            MessageBox.Show(mensaje.ToString(), "Consulta de disponibilidad",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            int total = 20, ocupados = ContarOcupados();
            int disponibles = total - ocupados;
            double porcentaje = (double)ocupados / total * 100;

            MessageBox.Show(
                $"Total de asientos: {total}\n\n" +
                $"Asientos ocupados: {ocupados}\n\n" +
                $"Asientos disponibles: {disponibles}\n\n" +
                $"Porcentaje de ocupación: {porcentaje:0.00}%",
                "Estadísticas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConsultarAsiento_Click(object sender, EventArgs e)
        {
            using Form ventana = new Form {
                Text = "Consultar asiento", StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(320, 150),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false, MinimizeBox = false
            };

            Label etiqueta = new Label {
                Text = "Escribe el asiento (ejemplo: A12):",
                AutoSize = true, Location = new Point(20, 20)
            };

            TextBox entrada = new TextBox {
                Location = new Point(20, 50), Width = 180
            };

            Button aceptar = new Button {
                Text = "Consultar", Location = new Point(210, 48), Width = 85
            };

            aceptar.Click += (s, args) =>
            {
                string asiento = entrada.Text.Trim().ToUpper();

                if (asiento.Length != 3 || asiento[0] != 'A' ||
                    !char.IsDigit(asiento[1]) || !char.IsDigit(asiento[2]))
                {
                    MessageBox.Show("Formato incorrecto. Ejemplo válido: A12",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int fila = int.Parse(asiento[1].ToString()) - 1;
                int columna = int.Parse(asiento[2].ToString()) - 1;

                if (fila < 0 || fila >= 4 || columna < 0 || columna >= 5)
                {
                    MessageBox.Show("El asiento no existe.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string estado = asientos[fila, columna] == 0 ? "disponible" : "ocupado";

                MessageBox.Show($"El asiento {asiento} está {estado}.",
                    "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            ventana.Controls.Add(etiqueta);
            ventana.Controls.Add(entrada);
            ventana.Controls.Add(aceptar);
            ventana.ShowDialog(this);
        }
    }
}
