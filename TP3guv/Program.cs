using System;

class TPTres
{

    static int[][] vuelo;
    static void Main()
    {

        Console.WriteLine("------ BIENVENIDOS A LA AEROLINEA GUV ------");

        int menu = 1;

        do
        {
            Console.WriteLine("\nMenu: ");
            Console.WriteLine("1. Creacion de vuelos y asientos. ");
            Console.WriteLine("2. Reservar asiento. ");
            Console.WriteLine("3. Cancelar reservas.");
            Console.WriteLine("4. Mostrar estado. ");
            Console.WriteLine("5. Mostrar estadisticas");
            Console.WriteLine("6. Salir");

            Console.Write("\nElige una opcion: ");
            menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
               
                case 1:
                    creacionVuelosYAsientos();
                    break;
                case 2:
                    reservaAsiento();
                    //Console.WriteLine("Reservar asientos.");
                    break;
                case 3:
                    cancelarReserva();
                    //Console.WriteLine("Cancelar reservas");
                    break;
                case 4:
                    MostrarEstado();
                    //Console.WriteLine("Mostrar estado");
                    break;
                case 5:
                    estadisticas();
                    //Console.WriteLine("Mostrar estadisticas");
                    break;
                case 6:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opcion incorrecta");
                    break;

            }
        } while (menu != 6);


    }

    //Creacion de vuelo y sus asientos
    /*static int Creacion_vueloYAsientos()
    {
        //Ejercicio N°1
        int[][] vuelos = new int[1][];

        for (int i = 1; i < 62; i++)
        {
            Array.Resize(ref vuelos[0], i);

            vuelos[0][i - 1] = 0;
        }

        for (int j = 0; j < vuelos[0].Length; j++)
        {
            Console.WriteLine($"vuelos [0][{j}]= {vuelos[0][j]}");

        }

        Console.ReadKey();
        return 1;
    }*/

    //otro codigo para los asientos

    static void creacionVuelosYAsientos()
    {
        vuelo = new int[1][]; // se declara una matriz jagged con 1 fila ( osea un solo vuelo)

        vuelo[0] = new int[60]; // inicializa el vuelo 0 con 61 asientos

        for (int j = 0; j < vuelo[0].Length; j++)
        {
            vuelo[0][j] = 0;

        }
        //hay que crear una matriz con dos ciclos for 

        Console.WriteLine("\nEl vuelo y sus asientos estan creados");
        Console.WriteLine("\nTodos los asientos estan disponibles (0)");

    }


    static void reservaAsiento()
    {
        
        if (vuelo == null)
        {
            Console.WriteLine("\nPrimero debes crear el vuelo y sus asientos ( Opcion 1 del menu)");
            return;
        }

        int numeroAsiento;
        bool asientoReservado = false;
        do
        {
            Console.Write("Ingrese el numero de asiento que quiere reservar (1-60): ");
            numeroAsiento = int.Parse(Console.ReadLine());

            if (numeroAsiento <=0  || numeroAsiento >=61)
            {
                Console.WriteLine("\nEl numero de asiento no es valido. Intente de nuevo.");
            }
            else if (vuelo[0][numeroAsiento-1] == 0) //si el asiento esta disponible
            {
                vuelo[0][numeroAsiento-1] = 1; // marcalo con el 1 para que este ocupado.
                Console.WriteLine($"\nEl asiento {numeroAsiento} esta reservado con exito.");
                asientoReservado = true; // hace que se salga del bucle porque se cambio a true 
            }
            else
            {
                Console.WriteLine($"\nEl asiento {numeroAsiento} esta ocupado.");

            }
        } while (!asientoReservado); // repite el bucle mientras los asientos estan disponibles


    }

    //Mostrar estado
    static void MostrarEstado()
    {
        if (vuelo == null)
        {
            Console.WriteLine("Vuelo no creado. Opcion 1 para crear el vuelo y sus asientos");
            return;
        }

        Console.WriteLine("\nEstado del vuelo con sus asientos: ");

        for (int j = 0; j < vuelo[0].Length; j++)
        {
            string estado;

            if (vuelo[0][j] == 0)
            {
                estado = "Disponible";
            }
            else
            {
                estado = "Ocupado";
            }
            Console.WriteLine($"\nEl asiento {j+1}: {estado}");
        }

    }

    //Cancelar reserva
    static void cancelarReserva()
    {
        if (vuelo[0] == null)
        {
            Console.WriteLine("Primero debe crear el vuelo y sus asientos. Oprima opcion 1");
            return;
        }

        Console.WriteLine("Ingrese el asiento reservado para cancelarlo (1-60)"); // se le solicita al usuario el numero de asiento q quiere cancelar
        int asientoReservado = int.Parse(Console.ReadLine());

        if (asientoReservado <= 0 || asientoReservado >=61) //aca verificamos si el numero ingresado es valido, osea si esta dentro del rango
        {
            Console.WriteLine("\nNo estas dentro del rango.Intente de nuevo");
            return;
        }

        if (vuelo[0][asientoReservado-1] == 1) // verificamos si el asiento esta ocupado, si es true, el asiento que elegimos va a estar disponible
        {
            vuelo[0][asientoReservado-1] = 0; // aca marca el asiento como disponible
            Console.WriteLine($"\nReserva del asiento {asientoReservado} cancelado");
        }
        else
        {
            Console.WriteLine($"\nEl asiento{asientoReservado} no esta reservado, por lo tanto no se puede cancelar.");
        }
    }

    //Mostrar asientos disponibles y ocupados

    static void estadisticas()
    {
        if (vuelo == null)
        {
            Console.WriteLine("Debes crear el vuelo y sus asientos para ver la disponibilidad de asientos. Opcion 1 en el menu");
            return;
        }

        //Contadores para los asientos disponibles y ocupados

        int asientosDisponibles = 0;
        int asientosOcupados = 0;

        Console.WriteLine("\nEstado actual de los asientos del vuelo: ");

        for (int i = 0; i < vuelo[0].Length; i++)  // int i= inicializa el indice en 0(el primer asiento), i++ incrementa el indice con cada iteraccion para pasar al siguiente asiento
        {
            string estado;
            if (vuelo[0][i] == 0) //si el vuelo 0 y el asiento i es igual a 0
            {
                estado = "Disponible";
                asientosDisponibles++; //conta los asientos disponibles
            }
            else
            {
                estado = "Ocupado";
                asientosOcupados++; //sino, los asientos ocupados
            }

        }

        //Console.WriteLine($"Asiento {i}: {estado}");

        //Para mostrar todos los asientos disponibles y ocupados
        Console.WriteLine($"\n Total de los asientos disponibles: {asientosDisponibles}");
        Console.WriteLine($"\n Total de los asientos ocupados: {asientosOcupados}");
    }

  
  


    
}