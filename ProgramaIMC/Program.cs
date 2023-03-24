﻿using ProgramaIMC.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaIMC
{
    public partial class Program
    {   
        static void Main(string[] args)
        {
            while (Menu()) ;
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("1. Ingresar");
            Console.WriteLine("2. Mostrar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("0. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1": IngresarPersona();
                    break;
                case "2": MostrarPersona();
                    break;
                case "3": BuscarPersona();
                    break;
                case "0": continuar = false;
                    break;
                default: Console.WriteLine("Apriete bien una tecla gil!");
                    break;
            }
            return continuar;
        }



        static void IngresarPersona()
        {
            string nombre;
            uint telefono;
            double peso;
            double estatura;

            Console.WriteLine("Bienvenido a nuestro programa de IMC");
            bool esValido;

            do
            {
                Console.WriteLine("Ingrese nombre ");
                nombre = Console.ReadLine().Trim();
            } while (nombre.Equals(string.Empty));

            do 
            {
                Console.WriteLine("Ingrese telefono: ");
                esValido = UInt32.TryParse(Console.ReadLine(), out telefono);
            } while(!esValido);

            do
            {
                Console.WriteLine("Ingrese su peso: ");
                esValido = Double.TryParse(Console.ReadLine(), out peso);
            } while (!esValido);

            do
            {
                Console.WriteLine("Ingrese su estatura: ");
                esValido = Double.TryParse(Console.ReadLine(), out estatura);
            } while (!esValido);

            Persona p = new Persona();
            p.Nombre = nombre;

            Console.WriteLine("Nombre : {0} ", nombre);
            Console.WriteLine("Telefono : {0} ", telefono);
            Console.WriteLine("Peso : {0} ", peso);
            Console.WriteLine("Estatura : {0}", estatura);
            Console.WriteLine("Su IMC es : {0}", peso / (estatura * estatura));
            Console.ReadKey();

        }
        static void MostrarPersona()
        {

        }

        static void BuscarPersona()
        {

        }
    }
}
