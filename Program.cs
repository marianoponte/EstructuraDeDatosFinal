using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace EstructuraDeDatosTP
{
    class Program
    {
        public static Stack pila;
        static void Main(string[] args)
        {

            int opcion = 0;
            while (opcion != 9)
            {
                try
                {

                    Console.WriteLine("---------------------------------------------------------------");
                    Console.WriteLine("-------- Bienvenido al Programa de control de Patentes --------");
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.WriteLine("");

                    Console.WriteLine("1. Crear Pila");
                    Console.WriteLine("2. Borrar Pila");
                    Console.WriteLine("3. Agregar Patente");
                    Console.WriteLine("4. Borrar Patente");
                    Console.WriteLine("5. Listar todas las Patentes");
                    Console.WriteLine("6. Listar última Patente");
                    Console.WriteLine("7. Listar primera Patente");
                    Console.WriteLine("8. Cantidad de Patentes");
                    Console.WriteLine("9. Salir");
                    Console.WriteLine("");
                    Console.WriteLine("11. Ordenar Pila alfabéticamente");
                    Console.WriteLine("12. Invertir orden de la Pila");
                    Console.WriteLine("");

                    Console.Write("Ingrese opción: ");


                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Stack pilaPatentes;
                            pilaPatentes = CrearPila();
                            pila = pilaPatentes;
                            Console.Clear();
                            Console.WriteLine("La Pila de Patentes ha sido creada con éxito.");
                            Console.WriteLine("Para continuar presione una tecla...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            pila = BorrarPila(ref pila);
                            break;

                        case 3:
                            pila = AgregarPatente(ref pila);
                            break;
                        case 4:
                            pila = BorrarPatente(ref pila);
                            break;
                        case 5:
                            pila = ListarPatentes(ref pila);
                            break;
                        case 6:
                            pila = UltimaPatente(ref pila);
                            break;
                        case 7:
                            pila = PrimeraPatente(ref pila);
                            break;
                        case 8:
                            pila = CantidadPatentes(ref pila);
                            break;
                        case 9:
                            break;
                        case 11:
                            pila = OrdenarPila(ref pila);
                            break;
                        case 12:
                            pila = InvertirPila(ref pila);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Ingresó una opción inválida");
                            Console.WriteLine("Para continuar presione una tecla...");
                            Console.ReadKey();
                            Console.Clear();
                            break;


                    }

                }

                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ingresó un caracter inválido");
                    Console.WriteLine("Para continuar presione una tecla...");
                    Console.ReadKey();
                    Console.Clear();

                }
            }
        }


        public static Stack CrearPila()
        {
            Stack pilaPatentes = new Stack();
            return pilaPatentes;

        }

        public static Stack BorrarPila(ref Stack pila)
        {
            try
            {
                Console.Clear();
                pila.Clear();
                Console.WriteLine("La Pila de patentes fue vaciada con éxito.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return pila;
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La Pila no fue creada todavía.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return pila;
            }
        }

        public static ref Stack AgregarPatente(ref Stack pila)
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese la Patente que desea agregar: ");
                String patente;
                patente = Console.ReadLine();
                bool valido = Regex.IsMatch(patente, @"^[A-Z]{3}[0-9]{3}$");
                if (valido)
                {
                    Console.WriteLine("La Patente se ha agregado con éxito.");
                    Console.WriteLine("Para continuar presione una tecla...");
                    pila.Push(patente);
                    Console.ReadKey();
                    Console.Clear();
                    return ref pila;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("La patente que quiere agregar no es válida.");
                    Console.WriteLine("Recuerde: La Patente debe tener el formato de 3 letras mayúsculas seguidas de 3 números. (XXX 123)");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    return ref pila;
                }
            }

            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La Pila no fue creada todavía.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return ref pila;
            }


        }

        public static ref Stack BorrarPatente(ref Stack pila)
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese la Patente que desea borrar: ");
                String patenteABorrar = Console.ReadLine();

                if (pila.Contains(patenteABorrar))
                {
                    ArrayList lista = new ArrayList();
                    foreach (string dato in pila)
                    {
                        lista.Add(dato);
                    }

                    pila.Clear();
                    int posicion = lista.IndexOf(patenteABorrar);
                    lista.RemoveAt(posicion);
                    Console.WriteLine("La Patente ha sido borrada con éxito.");
                    Console.WriteLine("Para continuar presione una tecla...");
                    Console.ReadKey();
                    Console.Clear();

                    lista.Reverse();

                    foreach (var dato in lista)
                    {
                        pila.Push(dato);
                    }

                    return ref pila;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("La Patente no se ha encontrado.");
                    Console.WriteLine("Para continuar presione una tecla...");
                    Console.ReadKey();
                    Console.Clear();
                    return ref pila;
                }




            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La Pila no fue creada todavía.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return ref pila;
            }

        }
        public static ref Stack ListarPatentes(ref Stack pila)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Las Patentes cargadas son: ");
                Console.WriteLine("");

                foreach (var elemento in pila)
                {
                    Console.WriteLine(elemento);
                }

                Console.WriteLine("");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();

                return ref pila;

            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La Pila no fue creada todavía.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return ref pila;
            }

        }

        public static ref Stack UltimaPatente(ref Stack pila)
        {
            try
            {
                Console.Clear();

                var ultimaPatente = pila.Peek();
                Convert.ToString(ultimaPatente);

                Console.WriteLine("La última Patente agregada es: {0}", ultimaPatente);
                Console.WriteLine("Para continuar presione una tecla...");

                Console.ReadKey();
                Console.Clear();
                return ref pila;

            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La Pila no fue creada todavía.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return ref pila;
            }
            catch (InvalidOperationException)
            {
                Console.Clear();
                Console.WriteLine("La Pila está vacía");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadLine();
                Console.Clear();
                return ref pila;

            }


        }

        public static ref Stack PrimeraPatente(ref Stack pila)
        {
            try
            {
                Console.Clear();
                ArrayList lista = new ArrayList();

                foreach (string dato in pila)
                {
                    lista.Add(dato);
                }

                var primera = lista[lista.Count - 1];
                Convert.ToString(primera);

                Console.WriteLine("La primera Patente agregada es: {0}", primera);
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return ref pila;
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La Pila no fue creada todavía.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return ref pila;
            }
            catch (InvalidOperationException)
            {
                Console.Clear();
                Console.WriteLine("La Pila esta vacía");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadLine();
                Console.Clear();
                return ref pila;

            }
            catch (ArgumentOutOfRangeException)         
            {
                Console.Clear();
                Console.WriteLine("La Pila está vacía.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadLine();
                Console.Clear();
                return ref pila;
            }

        }

        public static ref Stack CantidadPatentes(ref Stack pila)
        {
            try
            {
                int total;
                total = pila.Count;

                Console.Clear();
                Console.WriteLine("La cantidad total de Patentes hasta el momento es de: {0}", total);
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return ref pila;
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La Pila no fue creada todavía.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return ref pila;
            }

        }

        public static ref Stack OrdenarPila(ref Stack pila)
        {
            try
            {
                ArrayList lista = new ArrayList();
                foreach (string dato in pila)
                {
                    lista.Add(dato);
                }

                pila.Clear();

                lista.Sort();

                Console.Clear();
                Console.WriteLine("La Pila se ha ordenado alfabéticamente: ");
                Console.WriteLine("");
    
                foreach(var elemento in lista)
                {
                    Console.WriteLine(elemento);
                }

                Console.WriteLine("");
                Console.WriteLine("Para continuar presione una tecla...");

                foreach (var dato in lista)
                {
                    pila.Push(dato);
                }
                
                Console.ReadKey();
                Console.Clear();



                return ref pila;
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La Pila no fue creada todavía.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return ref pila;
            }


        }

        public static ref Stack InvertirPila(ref Stack pila)
        {
            try
            {
                ArrayList lista = new ArrayList();
                foreach (string dato in pila)
                {
                    lista.Add(dato);
                }

                pila.Clear();

                foreach (var dato in lista)
                {
                    pila.Push(dato);
                }

                Console.Clear();
                Console.WriteLine("Se ha invertido el orden de la Pila con éxito.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();

                return ref pila;

            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La Pila no fue creada todavía.");
                Console.WriteLine("Para continuar presione una tecla...");
                Console.ReadKey();
                Console.Clear();
                return ref pila;
            }


        }




    }
}