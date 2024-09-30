using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using BE;
using BL;
using Service;

namespace KwikEMart
{
    public partial class frmSerializacion : Form, IObserver
    {
        private UsuarioBE usuarioActual;
        public frmSerializacion()
        {
            InitializeComponent();
            TraerTodosClientes();
            usuarioActual = SessionManager.GetInstance().User;
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }



        ClienteBLL clienteBLL = new ClienteBLL();
        public void TraerTodosClientes()
        {
            DataTable dt = clienteBLL.ObtenerClientes();

            foreach (DataRow dr in dt.Rows)
            {
                string registro = $"{dr["DNI"]} - {dr["Nombre"]} {dr["Apellido"]}";
                listBoxDatosDeserializados.Items.Add(registro);
            }
        }

        private void SerializarXML(ClienteBE cliente, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ClienteBE));
                serializer.Serialize(fs, cliente);
            }
        }



        private void MostrarArchivoSerializado(string path)
        {
            listBoxArchivoSerializado.Items.Clear();

            string[] lineas = File.ReadAllLines(path);

            foreach (string linea in lineas)
            {
                listBoxArchivoSerializado.Items.Add(linea);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void MostrarDatosDeserializados(ClienteBE cliente)
        {
            listBoxDatosDeserializados.Items.Clear();

            listBoxDatosDeserializados.Items.Add($"DNI: {cliente.DNI}");
            listBoxDatosDeserializados.Items.Add($"Nombre: {cliente.Nombre}");
            listBoxDatosDeserializados.Items.Add($"Apellido: {cliente.Apellido}");
            listBoxDatosDeserializados.Items.Add($"Direccion: {cliente.Direccion}");
            listBoxDatosDeserializados.Items.Add($"Telefono: {cliente.Telefono}");
        }

        private ClienteBE DeserializarXML(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ClienteBE));
                return (ClienteBE)serializer.Deserialize(fs);
            }
        }

        Bitacora evento = new Bitacora();
        BitacoraEventosBLL bitacoraEventosBLL = new BitacoraEventosBLL();

        private void btnSerializar_Click_1(object sender, EventArgs e)
        {
            string selectedItem = listBoxDatosDeserializados.SelectedItem.ToString();

            string dniString = selectedItem.Split()[0];

            int dnicliente = int.Parse(dniString);

            ClienteBE cliente = clienteBLL.ObtenerClienteXDNI(dnicliente);

            string Path = $"XML/{cliente.DNI} - {cliente.Nombre} {cliente.Apellido}.xml";

            SerializarXML(cliente, Path);
            MostrarArchivoSerializado(Path);

            evento.DNIusuario = usuarioActual.DNI;
            evento.Evento = "Se serializó al cliente con DNI: " + cliente.DNI;
            evento.FechaHora = DateTime.Now;
            evento.Riesgo = 5;
            bitacoraEventosBLL.AgregarEventoObj(evento);

            MessageBox.Show("Cliente serializado con éxito!");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = $"/XML|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                listBoxArchivoSerializado.Items.Clear();


                ClienteBE cliente = DeserializarXML(openFileDialog.FileName);

                evento.DNIusuario = usuarioActual.DNI;
                evento.Evento = "Se deserializó al cliente con DNI: " + cliente.DNI;
                evento.FechaHora = DateTime.Now;
                evento.Riesgo = 5;
                bitacoraEventosBLL.AgregarEventoObj(evento);

                MostrarDatosDeserializados(cliente);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBoxDatosDeserializados.Items.Clear();
            

            TraerTodosClientes();

            listBoxArchivoSerializado.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KwikEMart menu = new KwikEMart();
            menu.Show();
            this.Close();
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
    }
}

