using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial1_AP1.BLL;
using Parcial1_AP1.DAL;
using Parcial1_AP1.Entidades;


namespace Parcial1_AP1.UI.Registros
{
    public partial class Registro : Form
    {
        public object ID { get; private set; }
        public object FechaDateTimePicker { get;  set; }
        public object Estudiante { get; private set; }
        public object EstudianteTexbox { get; private set; }

        public Registro()
        {
            InitializeComponent();
        }
        public void limpiar()
        {
            ID.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            EstudianteTextBox.Text = string.Empty;
            Valor.Text = string.Empty;
            LogradoNumericUpDown3.Text = string.Empty;
            PerdidonumericUpDown.Text = string.Empty;
            PronosticoComboBox.Text = string.Empty;
            
            ErrorProvider.Clear();

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private REvaluacion LlenaClase()
        {
            REvaluacion estudiante = new REvaluacion();
            estudiante.ID = Convert.ToInt32(ID.Value);
            estudiante.Fecha = FechaDateTimePicker.Value;
            estudiante.Estudiante =EstudianteTextBox.Text;
              estudiante.Fecha = FechaDateTimePicker.Value;
            estudiante.Pronostico = PronosticoComboBox.SelectedIndex;
            estudiante.Valor = Convert.ToDecimal(ValorTextBox.Text);



            return estudiante;
        }
        private REvaluacion LlenaClase(REvaluacion estudiante)
        {

            ID.Value = estudiante.ID;
            FechaDateTimePicker.Value = estudiante.Fecha;
            EstudianteTextBox.Text = estudiante.Estudiante;
            PronosticoComboBox.SelectedIndex = (int)estudiante.Pronostico;
            ValorTextBox.Text = estudiante.Valor.ToString("N2");
            LogradoTextBox.Text = estudiante.Valor.ToString("N2");
            PerdidoTextBox.Text = estudiante.Valor.ToString("N2");


            

            return estudiante;
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Guardarbutton3_Click(object sender, EventArgs e)
        {
            REvaluacion estudiante;
            bool paso = false;

            if (!Validar())
                return;

            estudiante = LlenaClase();


            //Determinar si es guardar o modificar
            if (ID.Value == 0)
                paso = EvaluacionBLL.Guardar(estudiante);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                estudiante = new REvaluacion();
                estudiante = EvaluacionBLL.Buscar(Convert.ToInt32(REvaluacion.Value));
                estudiante.ID = IDTextBox.Text;
                estudiante.Estudiante = EstudianteTextbox.Text;
                estudiante.Valor = ValorTextbox.Text;
                estudiante.dateTimePicker = dateTimePicker.Value;
                estudiante.Pronostico = PronosticoComboBox.SelectedIndex;
                estudiante.Logrado = Convert.ToDecimal(logradoTextBox.Text);

                paso = EstudiantesBILL.Modificar(estudiante);
            }

            limpiar();
            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private bool Validar()
        {
            bool paso = true;
            ErrorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(EstudianteTextBox.Text))
            {
                ErrorProvider1.SetError(EstudianteTextBox, "El campo  no puede estar vacio");
                EstudianteTextBox.Focus();
                paso = false;
            }

            if (ValorTextbox.Text == string.Empty)
            {
                ErrorProvider1.SetError(, "El campo  no puede estar vacio");
                ValorTextbox.Focus();
                paso = false;
            }

            if (ApellidoTextbox.Text == string.Empty)
            {
                MyerrorProvider.SetError(ApellidoTextbox, "El campo no puede estar vacio");
                ApellidoTextbox.Focus();
                paso = false;
            }

            return paso;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            REvaluacion persona = EvaluacionBLL.Buscar((int)REvaluacion.Value);

            return (persona != null);
        }

       
        private void Buscarbutton1_Click(object sender, EventArgs e)
        {
            int id;
            REvaluacion estudiante = new REvaluacion();
            int.TryParse(ID.Text, out id);

            limpiar();

            estudiante = BLL.Buscar(id);

            if (estudiante != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaClase(estudiante);
            }
            else
            {
                MessageBox.Show("Persona no Encontada");
            }
        }

        private void Eliminarbutton2_Click(object sender, EventArgs e)
        {
            ErrorProvider1.Clear();
            int id;
            int.TryParse(ID.Text, out id);
            limpiar();
            if (EvaluacionBLL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                ErrorProvider.SetError(ID, "No se puede eliminar una persona que no existe");
        }

        private void BalanceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}