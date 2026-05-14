using System;
using System.Collections.Generic;

/// <summary>
/// Sistema de clasificación de pedidos para una tienda en línea.
/// Permite registrar pedidos y generar reportes.
/// </summary>
class Proyecto
{
    // ============================
    // CONSTANTES
    // ============================
    const decimal LIMITE_ENVIO_GRATIS = 150000;
    const decimal LIMITE_ENVIO_EXPRESS = 300000;
    const int LIMITE_ITEMS = 5;

    // ============================
    // LISTAS
    // ============================
    static List<decimal> listaMontos = new List<decimal>();
    static List<string> listaClientes = new List<string>();
    static List<int> listaItems = new List<int>();
    static List<string> listaCiudades = new List<string>();
    static List<string> listaCategorias = new List<string>();

    // ============================
    // MAIN
    // ============================
    static void Main(string[] args)
    {
        EjecutarSistema();
    }

    // ============================
    // ORQUESTACIÓN
    // ============================

    /// <summary>
    /// Controla el flujo principal del sistema.
    /// </summary>
    static void EjecutarSistema()
    {
        int opcion;

        do
        {
            opcion = MostrarMenu();

            switch (opcion)
            {
                case 1:
                    RegistrarPedido();
                    break;

                case 2:
                    MostrarReportes();
                    break;

                case 3:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 3);
    }

    // ============================
    // MENÚ
    // ============================

    /// <summary>
    /// Muestra el menú principal y retorna la opción seleccionada.
    /// </summary>
    /// <returns>Opción ingresada por el usuario.</returns>
    static int MostrarMenu()
    {
        int opcion;

        while (true)
        {
            Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Registrar pedido");
            Console.WriteLine("2. Ver reportes");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                return opcion;
            }

            Console.WriteLine("Error: Ingrese una opción válida.");
        }
    }

    // ============================
    // REGISTRO DE PEDIDOS
    // ============================

    /// <summary>
    /// Registra un pedido en el sistema.
    /// </summary>
    static void RegistrarPedido()
    {
        Console.WriteLine("\n=== REGISTRO DE PEDIDO ===");

        decimal monto = LeerMonto();
        string ciudad = LeerCiudad();
        string cliente = LeerTipoCliente();
        int items = LeerCantidadItems();

        string categoria = CalcularCategoria(monto, cliente, items);

        GuardarPedido(monto, ciudad, cliente, items, categoria);

        Console.WriteLine($"Pedido registrado como: {categoria}");
    }

    // ============================
    // FUNCIONES DE ENTRADA
    // ============================

    /// <summary>
    /// Solicita y valida el monto del pedido.
    /// </summary>
    /// <returns>Monto válido.</returns>
    static decimal LeerMonto()
    {
        decimal monto;

        while (true)
        {
            Console.Write("Monto del pedido: ");

            if (decimal.TryParse(Console.ReadLine(), out monto) && monto >= 0)
            {
                return monto;
            }

            Console.WriteLine("Error: Ingrese un monto válido.");
        }
    }

    /// <summary>
    /// Solicita y valida la ciudad destino.
    /// </summary>
    /// <returns>Ciudad válida.</returns>
    static string LeerCiudad()
    {
        string ciudad;

        while (true)
        {
            Console.Write("Ciudad destino: ");
            ciudad = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(ciudad))
            {
                return ciudad;
            }

            Console.WriteLine("Error: La ciudad no puede estar vacía.");
        }
    }

    /// <summary>
    /// Solicita y valida el tipo de cliente.
    /// </summary>
    /// <returns>Tipo de cliente válido.</returns>
    static string LeerTipoCliente()
    {
        string cliente;

        while (true)
        {
            Console.Write("Tipo de cliente (nuevo/recurrente): ");
            cliente = Console.ReadLine().ToLower();

            if (cliente == "nuevo" || cliente == "recurrente")
            {
                return cliente;
            }

            Console.WriteLine("Error: Escriba 'nuevo' o 'recurrente'.");
        }
    }

    /// <summary>
    /// Solicita y valida la cantidad de artículos.
    /// </summary>
    /// <returns>Cantidad válida de artículos.</returns>
    static int LeerCantidadItems()
    {
        int items;

        while (true)
        {
            Console.Write("Cantidad de items: ");

            if (int.TryParse(Console.ReadLine(), out items) && items >= 0)
            {
                return items;
            }

            Console.WriteLine("Error: Ingrese una cantidad válida.");
        }
    }

    // ============================
    // LÓGICA DE NEGOCIO
    // ============================

    /// <summary>
    /// Calcula la categoría de envío según las reglas del negocio.
    /// </summary>
    /// <param name="monto">Monto total del pedido.</param>
    /// <param name="cliente">Tipo de cliente.</param>
    /// <param name="items">Cantidad de artículos.</param>
    /// <returns>Categoría de envío.</returns>
    static string CalcularCategoria(decimal monto, string cliente, int items)
    {
        if (monto >= LIMITE_ENVIO_GRATIS && cliente == "recurrente")
        {
            return "Envío Gratis";
        }

        if (items > LIMITE_ITEMS || monto >= LIMITE_ENVIO_EXPRESS)
        {
            return "Envío Express";
        }

        return "Envío Estándar";
    }

    // ============================
    // ALMACENAMIENTO
    // ============================

    /// <summary>
    /// Guarda un pedido en las listas del sistema.
    /// </summary>
    /// <param name="monto">Monto total del pedido.</param>
    /// <param name="ciudad">Ciudad destino del pedido.</param>
    /// <param name="cliente">Tipo de cliente.</param>
    /// <param name="items">Cantidad de artículos.</param>
    /// <param name="categoria">Categoría de envío calculada.</param>
    static void GuardarPedido(decimal monto, string ciudad, string cliente, int items, string categoria)
    {
        listaMontos.Add(monto);
        listaCiudades.Add(ciudad);
        listaClientes.Add(cliente);
        listaItems.Add(items);
        listaCategorias.Add(categoria);
    }

    // ============================
    // REPORTES
    // ============================

    /// <summary>
    /// Muestra las estadísticas generales del sistema.
    /// </summary>
    static void MostrarReportes()
    {
        Console.WriteLine("\n=== REPORTES ===");

        if (listaMontos.Count == 0)
        {
            Console.WriteLine("No hay pedidos registrados.");
            return;
        }

        int totalPedidos = ObtenerTotalPedidos();
        decimal promedio = CalcularPromedioMontos();

        int gratis = ContarCategoria("Envío Gratis");
        int express = ContarCategoria("Envío Express");
        int estandar = ContarCategoria("Envío Estándar");

        Console.WriteLine($"Total pedidos: {totalPedidos}");
        Console.WriteLine($"Promedio de monto: {promedio}");
        Console.WriteLine($"Envíos Gratis: {gratis}");
        Console.WriteLine($"Envíos Express: {express}");
        Console.WriteLine($"Envíos Estándar: {estandar}");
    }

    // ============================
    // FUNCIONES DE CÁLCULO
    // ============================

    /// <summary>
    /// Obtiene el total de pedidos registrados.
    /// </summary>
    /// <returns>Total de pedidos.</returns>
    static int ObtenerTotalPedidos()
    {
        return listaMontos.Count;
    }

    /// <summary>
    /// Calcula el promedio de montos registrados.
    /// </summary>
    /// <returns>Promedio de montos.</returns>
    static decimal CalcularPromedioMontos()
    {
        decimal suma = 0;

        foreach (decimal monto in listaMontos)
        {
            suma += monto;
        }

        return suma / listaMontos.Count;
    }

    /// <summary>
    /// Cuenta cuántos pedidos pertenecen a una categoría específica.
    /// </summary>
    /// <param name="categoria">Categoría de envío a contar.</param>
    /// <returns>Cantidad de pedidos encontrados.</returns>
    static int ContarCategoria(string categoria)
    {
        int contador = 0;

        foreach (string item in listaCategorias)
        {
            if (item == categoria)
            {
                contador++;
            }
        }

        return contador;
    }
}
