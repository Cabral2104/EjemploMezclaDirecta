using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploMezclaDirecta
{
    internal class Program
    {

            static int[] LeerDatos()
        {
            
            string input = Console.ReadLine();
            string[] elementos = input.Split(' ');
            int[] datos = new int[elementos.Length];

            for (int i = 0; i < elementos.Length; i++)
            {
                datos[i] = Convert.ToInt32(elementos[i]);
            }

            return datos;
        }

        static void MostrarDatos(int[] datos)
        {
            foreach (var elemento in datos)
            {
                Console.Write(elemento + " ");
            }
            Console.WriteLine();
        }

        static void MezclaDirecta(int[] datos, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int medio = (izquierda + derecha) / 2;

                // Dividir la lista en dos mitades y ordenar cada mitad
                MezclaDirecta(datos, izquierda, medio);
                MezclaDirecta(datos, medio + 1, derecha);

                // Combinar las dos mitades ordenadas
                Combinar(datos, izquierda, medio, derecha);
            }
        }

        static void Combinar(int[] datos, int izquierda, int medio, int derecha)
        {
            int n1 = medio - izquierda + 1;
            int n2 = derecha - medio;

            // Crear arreglos temporales
            int[] izquierdaArray = new int[n1];
            int[] derechaArray = new int[n2];

            // Copiar datos a los arreglos temporales
            for (int i = 0; i < n1; ++i)
            {
                izquierdaArray[i] = datos[izquierda + i];
            }
            for (int j = 0; j < n2; ++j)
            {
                derechaArray[j] = datos[medio + 1 + j];
            }

            // Fusionar los arreglos temporales
            int indiceIzquierda = 0, indiceDerecha = 0;
            int indiceActual = izquierda;

            while (indiceIzquierda < n1 && indiceDerecha < n2)
            {
                if (izquierdaArray[indiceIzquierda] <= derechaArray[indiceDerecha])
                {
                    datos[indiceActual] = izquierdaArray[indiceIzquierda];
                    indiceIzquierda++;
                }
                else
                {
                    datos[indiceActual] = derechaArray[indiceDerecha];
                    indiceDerecha++;
                }
                indiceActual++;
            }

            // Copiar los elementos restantes de izquierdaArray, si los hay
            while (indiceIzquierda < n1)
            {
                datos[indiceActual] = izquierdaArray[indiceIzquierda];
                indiceIzquierda++;
                indiceActual++;
            }

            // Copiar los elementos restantes de derechaArray, si los hay
            while (indiceDerecha < n2)
            {
                datos[indiceActual] = derechaArray[indiceDerecha];
                indiceDerecha++;
                indiceActual++;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Algoritmo de Mezcla Directa en C#");

            do
            {
                // Solicitar al usuario que ingrese los datos
                Console.Write("Ingrese los elementos separados por espacio: ");
                int[] datos = LeerDatos();

                // Mostrar datos ingresados
                Console.WriteLine("Datos ingresados:");
                MostrarDatos(datos);

                // Obtener la hora de inicio
                var startTime = DateTime.Now;

                // Medir el tiempo de ejecución
                var stopwatch = Stopwatch.StartNew();

                // Aplicar el algoritmo de mezcla directa
                MezclaDirecta(datos, 0, datos.Length - 1);

                // Detener el temporizador
                stopwatch.Stop();

                // Mostrar los datos ordenados
                Console.WriteLine("Datos ordenados:");
                MostrarDatos(datos);

                // Obtener la hora de finalización
                var endTime = DateTime.Now;

                // Mostrar tiempo de inicio, tiempo de finalización y tiempo total de ejecución en segundos
                Console.WriteLine($"\nTiempo de inicio: {startTime}");
                Console.WriteLine($"Tiempo de finalización: {endTime}");
                Console.WriteLine($"Tiempo total transcurrido: {stopwatch.Elapsed.TotalSeconds:F10} segundos");

                // Preguntar al usuario si desea agregar más números
                Console.Write("¿Desea ingresar más números? (s/n): ");
            } while (Console.ReadLine() == "s");
            Console.ReadKey();
        }
    }
}
