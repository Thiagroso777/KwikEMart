using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Windows.Forms;

namespace Service
{
    public class LenguageManager : ISubject
    {
        private List<IObserver> ListaFormularios = new List<IObserver>();
        private Dictionary<string, string> Diccionario;

        //Patrón singleton

        private static LenguageManager instancia;

        private LenguageManager() { }

        public static LenguageManager ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new LenguageManager();
            }
            return instancia;
        }

        //Patrón observer

        public void Agregar(IObserver observer)
        {
            ListaFormularios.Add(observer);
        }
        public void Quitar(IObserver observer)
        {
            ListaFormularios.Remove(observer);
        }

        public void Notificar()
        {
            foreach (IObserver observer in ListaFormularios)
            {
                observer.ActualizarIdioma();
            }
        }

        public void CargarIdioma()
        {
            var NombreArchivo = $"{SessionManager.GetInstance().IdiomaActual}.json";
            var jsonString = File.ReadAllText(NombreArchivo);
            Diccionario = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
        }

        public string ObtenerTexto(string key)
        {
                return Diccionario.ContainsKey(key) ? Diccionario[key] : key;
           
        }

        public void CambiarIdiomaControles(Control frm)
        {
            try
            {
                frm.Text = LenguageManager.ObtenerInstancia().ObtenerTexto(frm.Name + ".Text");

                foreach (Control c in frm.Controls)
                {
                    if (c is Button || c is Label)
                    {
                        c.Text = ObtenerInstancia().ObtenerTexto(frm.Name + "." + c.Name);
                    }

                    if (c.Controls.Count > 0)
                    {
                        CambiarIdiomaControles(c);
                    }
                }
            }
            catch (Exception) { };
        }

        
    }
}
