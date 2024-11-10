
using System;

namespace ConvertidorIPv4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array para almacenar los cuatro octetos
            int[] octetos = new int[4];

            Console.WriteLine("Ingrese una dirección IPv4 en formato decimal (cada octeto entre 0 y 255).");

            // Bucle para solicitar cada octeto
            for (int i = 0; i < 4; i++)
            {
                int numero;
                bool esValido = false;

                // Solicita y valida que cada número esté en el rango de 0 a 255
                do
                {
                    Console.Write($"Ingrese el octeto {i + 1} (0-255): ");
                    if (int.TryParse(Console.ReadLine(), out numero) && numero >= 0 && numero <= 255)
                    {
                        octetos[i] = numero;
                        esValido = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: El número debe estar entre 0 y 255.");
                    }
                } while (!esValido);
            }

            // Muestra la dirección IPv4 en formato decimal
            Console.WriteLine($"\nIPv4 en notación decimal: {octetos[0]}.{octetos[1]}.{octetos[2]}.{octetos[3]}");

            // Convierte y muestra cada octeto en binario y hexadecimal
            Console.WriteLine("Notación en binario:");
            foreach (int octeto in octetos)
            {
                Console.Write(ConvertirABinario(octeto).PadLeft(8, '0') + ".");
            }
            Console.WriteLine();

            Console.WriteLine("Notación en hexadecimal:");
            foreach (int octeto in octetos)
            {
                Console.Write(ConvertirAHexadecimal(octeto).PadLeft(2, '0') + ".");
            }
            Console.WriteLine();
        }

        // Método para convertir de decimal a binario usando switch
        static string ConvertirABinario(int numero)
        {
            string binario = "";
            int resto;
            int valor = numero;

            // Convertir el número decimal a binario
            while (valor > 0)
            {
                resto = valor % 2;
                binario = resto.ToString() + binario;
                valor /= 2;
            }

            return binario == "" ? "0" : binario;
        }

        // Método para convertir de decimal a hexadecimal usando switch
        static string ConvertirAHexadecimal(int numero)
        {
            string hex = "";
            int resto;
            int valor = numero;

            // Convertir el número decimal a hexadecimal
            while (valor > 0)
            {
                resto = valor % 16;
                switch (resto)
                {
                    case 10: hex = "A" + hex; break;
                    case 11: hex = "B" + hex; break;
                    case 12: hex = "C" + hex; break;
                    case 13: hex = "D" + hex; break;
                    case 14: hex = "E" + hex; break;
                    case 15: hex = "F" + hex; break;
                    default: hex = resto.ToString() + hex; break;
                }
                valor /= 16;
            }

            return hex == "" ? "0" : hex;
        }
    }
}
