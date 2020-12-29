using System;
using System.Collections.Generic;
using System.Text;

namespace UD6_M4
{
    public class Ejercicio
    {
        int billete5 = 0;
        int billete10 = 0;
        int billete20 = 0;
        int billete50 = 0;
        int billete100 = 0;
        int billete200 = 0;
        int billete500 = 0;

        int num_plato = 0;
        public void Principal()
        {
            string platoPedido = "";
           
            int precioTotalComida = 0;
            int pagoCliente = 0;
            int cambio = 0;

            string[] menu_array = new string[5];
            int[] precio_array = new int[5];

            string seguir = "";

            bool existe = true;
            bool correcto = false;


            Dictionary<string, int> carta = new Dictionary<string, int>();
            carta.Add("Entrecot", 50);
            carta.Add("Bacalao", 20);
            carta.Add("Huevos fritos", 7);
            carta.Add("Cafe con churros", 5);
            carta.Add("Bocata de calamares", 10);

            List<string> pedido = new List<string>();

            for (int i = 0; i < menu_array.Length; i++)
            {
                if (i == 0)
                {
                    menu_array[i] = "Entrecot";
                }
                else if (i == 1)
                {
                    menu_array[i] = "Bacalao";
                }
                else if (i == 2)
                {
                    menu_array[i] = "Huevos fritos";
                }
                else if (i == 3)
                {
                    menu_array[i] = "Cafe con churros";
                }
                else
                {
                    menu_array[i] = "Bocata de calamares";
                }

                precio_array[i] = carta[menu_array[i]];
            }

            Console.WriteLine("¿Que desea comer?");
            for (int i = 0; i < menu_array.Length; i++)
            {
                Console.WriteLine(menu_array[i] + " " + precio_array[i] + " euros");
            }
            seguir = "Si";
            while(seguir == "Si")
            {
                correcto = false;
                Console.WriteLine("Escoja un plato:");
                platoPedido = Console.ReadLine();
                try
                {
                    ExistePlato(platoPedido,menu_array);
                    pedido.Add(platoPedido);
                    precioTotalComida += precio_array[num_plato];

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("¿Quiere seguir pidiendo comida? Si / No");
                while (!correcto)
                {
                    try
                    {
                        seguir = Console.ReadLine();
                        SeguirPedido(seguir);
                        correcto = true;
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Opcion invalida. Vuelve a intentarlo de nuevo");
                    }
                }
            }

            Console.WriteLine("El precio total de la comida es " + precioTotalComida + " euros");
            while (!correcto || pagoCliente < precioTotalComida)
            {
                correcto = false;
                Console.WriteLine("Su importe actual es de: " + pagoCliente + " euros");
                Console.WriteLine("Introduzca la cantidad a pagar");
                try
                {
                    pagoCliente += Convert.ToInt32(Console.ReadLine());
                    correcto = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("El precio es incorrecto. Vuelve a intentarlo de nuevo");
                }
            }

            cambio = pagoCliente - precioTotalComida;
            if (cambio != 0)
            {
                CalcularCambio(cambio);
            }
        }

        void CalcularCambio( int cambio)
        {
            bool cambioFinalizado = false;
            int restaCambio = 0;

            while (!cambioFinalizado)
            {
                if (cambio >= 500)
                {
                    billete500 = cambio / 500;
                    restaCambio = billete500 * 500;
                    cambio -= restaCambio;
                }

                else if (cambio >= 200)
                {
                    billete200 = cambio / 200;
                    restaCambio = billete200 * 200;
                    cambio -= restaCambio;
                }

                else if (cambio >= 100)
                {
                    billete100 = cambio / 100;
                    restaCambio = billete100 * 100;
                    cambio -= restaCambio;
                }

                else if (cambio >= 50)
                {
                    billete50 = cambio / 50;
                    restaCambio = billete50 * 50;
                    cambio -= restaCambio;
                }

                else if (cambio >= 20)
                {
                    billete20 = cambio / 20;
                    restaCambio = billete20 * 20;
                    cambio -= restaCambio;
                }
                
                else if (cambio >= 10)
                {
                    billete10 = cambio / 10;
                    restaCambio = billete10 * 10;
                    cambio -= restaCambio;
                }

                else if(cambio >= 5)
                {
                    billete5 = cambio / 5;
                    restaCambio = billete5 * 5;
                    cambio -= restaCambio;
                }

                else
                {
                    Console.Write("El cambio te será dado ");
                    if (billete500 != 0) Console.Write("con " + billete500 + " billetes de 500 ");
                    if (billete200 != 0) Console.Write("con " + billete200 + " billetes de 200 ");
                    if (billete100 != 0) Console.Write("con " + billete100 + " billetes de 100 ");
                    if (billete50 != 0) Console.Write("con " + billete50 + " billetes de 50 ");
                    if (billete20 != 0) Console.Write("con " + billete20 + " billetes de 20 ");
                    if (billete10 != 0) Console.Write("con " + billete10 + " billetes de 10 ");
                    if (billete5 != 0) Console.Write("con " + billete5 + " billetes de 5 ");
                    Console.WriteLine("y " + cambio + " euros en monedas");
                    cambioFinalizado = true;
                }
            }
        }

        void ExistePlato(string platoPedido, string[] menu_array)
        {
            bool existe = false;
            
            for (int i = 0; i < menu_array.Length; i++)
            {
                if (platoPedido == menu_array[i])
                {
                    num_plato = i;
                    existe = true;
                }
            }

            if (!existe)
            {
                throw new InvalidOperationException("No existe este plato");
            }
            
        }
        
        void SeguirPedido(string seguir)
        {
            if (seguir != "Si" && seguir != "No")
            {
                throw new InvalidOperationException("No existe ese valor introducido, por favor ponga Si o No");
            }
        }
    }
}
