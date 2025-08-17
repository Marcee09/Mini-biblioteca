using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MiniBiblioteca
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public override string ToString() => $"{Titulo} - {Autor} ({Genero})";
    }

    public class FormBiblioteca : Form
    {
        private List<Libro> libros = new List<Libro>();
        private TextBox txtTitulo = new TextBox();
        private TextBox txtAutor = new TextBox();
        private TextBox txtGenero = new TextBox();
        private ListBox listBox = new ListBox();
        private Button btnAgregar = new Button { Text = "Agregar" };

        public FormBiblioteca()
        {
            // Configuración general del formulario
            Text = "Mini Biblioteca";
            Width = 500;
            Height = 400;
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 10);
            BackColor = Color.WhiteSmoke;

            // Tamaño de controles
            txtTitulo.Width = 250;
            txtAutor.Width = 250;
            txtGenero.Width = 250;
            listBox.Width = 350;
            listBox.Height = 150;

            // Estilos del botón agregar
            btnAgregar.BackColor = Color.LightBlue;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAgregar.Margin = new Padding(10);
            btnAgregar.Height = 40;

            // FlowLayoutPanel centrado (flex column + align-items center)
            var layout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(20),
                AutoSize = true
            };

            layout.Anchor = AnchorStyles.None;
            layout.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Agregar controles al layout
            layout.Controls.Add(new Label { Text = "Título:", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
            layout.Controls.Add(txtTitulo);
            layout.Controls.Add(new Label { Text = "Autor:", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
            layout.Controls.Add(txtAutor);
            layout.Controls.Add(new Label { Text = "Género:", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
            layout.Controls.Add(txtGenero);
            layout.Controls.Add(btnAgregar);
            layout.Controls.Add(listBox);

            Controls.Add(layout);

            // Evento del botón
            btnAgregar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                    string.IsNullOrWhiteSpace(txtAutor.Text) ||
                    string.IsNullOrWhiteSpace(txtGenero.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var libro = new Libro
                {
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    Genero = txtGenero.Text
                };

                libros.Add(libro);
                listBox.Items.Add(libro);

                txtTitulo.Clear();
                txtAutor.Clear();
                txtGenero.Clear();
            };
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBiblioteca());
        }
    }
}

