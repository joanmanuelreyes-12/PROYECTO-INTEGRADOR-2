namespace CineWindows
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblPantalla = new Label();
            pnlAsientos = new Panel();
            btnReservar = new Button();
            btnLiberar = new Button();
            btnDisponibilidad = new Button();
            btnEstadisticas = new Button();
            lblDisponibles = new Label();
            lblOcupados = new Label();
            lblPorcentaje = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(100, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(700, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "SISTEMA DE RESERVACIÓN DE CINE";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPantalla
            // 
            lblPantalla.Location = new Point(365, 90);
            lblPantalla.Name = "lblPantalla";
            lblPantalla.Size = new Size(170, 30);
            lblPantalla.TabIndex = 1;
            lblPantalla.Text = "PANTALLA";
            // 
            // pnlAsientos
            // 
            pnlAsientos.Location = new Point(145, 135);
            pnlAsientos.Name = "pnlAsientos";
            pnlAsientos.Size = new Size(610, 260);
            pnlAsientos.TabIndex = 2;
            // 
            // btnReservar
            // 
            btnReservar.Location = new Point(55, 430);
            btnReservar.Name = "btnReservar";
            btnReservar.Size = new Size(170, 42);
            btnReservar.TabIndex = 3;
            btnReservar.Text = "Reservar";
            btnReservar.UseVisualStyleBackColor = true;
            // 
            // btnLiberar
            // 
            btnLiberar.Location = new Point(260, 430);
            btnLiberar.Name = "btnLiberar";
            btnLiberar.Size = new Size(170, 42);
            btnLiberar.TabIndex = 4;
            btnLiberar.Text = "Liberar";
            btnLiberar.UseVisualStyleBackColor = true;
            // 
            // btnDisponibilidad
            // 
            btnDisponibilidad.Location = new Point(465, 430);
            btnDisponibilidad.Name = "btnDisponibilidad";
            btnDisponibilidad.Size = new Size(170, 42);
            btnDisponibilidad.TabIndex = 5;
            btnDisponibilidad.Text = "Consultar";
            btnDisponibilidad.UseVisualStyleBackColor = true;
            // 
            // btnEstadisticas
            // 
            btnEstadisticas.Location = new Point(670, 430);
            btnEstadisticas.Name = "btnEstadisticas";
            btnEstadisticas.Size = new Size(170, 42);
            btnEstadisticas.TabIndex = 6;
            btnEstadisticas.Text = "Estadísticas";
            btnEstadisticas.UseVisualStyleBackColor = true;
            // 
            // lblDisponibles
            // 
            lblDisponibles.AutoSize = true;
            lblDisponibles.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDisponibles.Location = new Point(100, 509);
            lblDisponibles.Name = "lblDisponibles";
            lblDisponibles.Size = new Size(116, 20);
            lblDisponibles.TabIndex = 7;
            lblDisponibles.Text = "Disponibles: 16";
            // 
            // lblOcupados
            // 
            lblOcupados.AutoSize = true;
            lblOcupados.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOcupados.Location = new Point(312, 509);
            lblOcupados.Name = "lblOcupados";
            lblOcupados.Size = new Size(95, 20);
            lblOcupados.TabIndex = 0;
            lblOcupados.Text = "Ocupados: 0";
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPorcentaje.Location = new Point(510, 509);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(112, 20);
            lblPorcentaje.TabIndex = 1;
            lblPorcentaje.Text = "Ocupación: 0%";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(884, 611);
            Controls.Add(lblPorcentaje);
            Controls.Add(lblDisponibles);
            Controls.Add(lblOcupados);
            Controls.Add(btnEstadisticas);
            Controls.Add(btnDisponibilidad);
            Controls.Add(btnLiberar);
            Controls.Add(btnReservar);
            Controls.Add(pnlAsientos);
            Controls.Add(lblPantalla);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Reservacion de Cine";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblPantalla;
        private Panel pnlAsientos;
        private Button btnReservar;
        private Button btnLiberar;
        private Button btnDisponibilidad;
        private Button btnEstadisticas;
        private Label lblDisponibles;
        private Label lblOcupados;
        private Label lblPorcentaje;
    }
}
