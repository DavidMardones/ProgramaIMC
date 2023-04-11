using ProgramaIMC.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPersonasModel.DAL
{
    public class PersonasDALArchivos : IPersonasDAL
    {
        private static string archivo = "personas.txt";
        private static string ruta = Directory.GetCurrentDirectory() + "/" + archivo;
        public void AgregarPersona(Persona p)
        {
            //1, Crear el StreamWriter 
            //2. Agregar una linea
            //3. Cerrar el StreamWriter

            try
            {
                using (StreamWriter write = new StreamWriter(ruta, true)) 
                {
                    string texto = p.Nombre + ";" + p.Estatura + ";" + p.Telefono + ";" + p.Peso + ";";
                    write.WriteLine(texto);
                    write.Flush();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al escribir en archivo" + ex.Message);
            }
            

        }

        public List<Persona> FiltrarPersonas(string nombre)
        {
            return ObtenerPersonas().FindAll(p => p.Nombre.ToLower() == nombre.ToLower());
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> personas = new List<Persona>();
            using (StreamReader reader = new StreamReader(ruta))
            {
                string texto;
                do
                {
                    //Leer desde el archivo hasta que no haya nada
                    texto = reader.ReadLine().Trim();
                    //Nombre; Estatura; Telefono; fono
                    string[] textoArr = texto.Split(';');
                    string nombre = textoArr[0];
                    double estatura = Convert.ToDouble(textoArr[1]);
                    uint telefono = Convert.ToUInt32(textoArr[2]);
                    double peso = Convert.ToDouble(textoArr[3]);

                    //Crear persona
                    Persona p = new Persona()
                    {
                        Nombre = nombre,
                        Estatura = estatura,
                        Telefono = telefono,
                        Peso = peso
                    };

                    //Calcular IMC
                    p.calcularImc();

                    //Agregar a la lista
                    personas.Add(p);

                } while (texto != null);
            }
            return personas;
        }
    }
}
