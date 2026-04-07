using System;
using System.Collections.Generic;

class Proyecto
{
    // ============================
    // CONSTANTES (SIN NÚMEROS MÁGICOS)
    // ============================
    const decimal LIMITE_ENVIO_GRATIS = 150000;
    const decimal LIMITE_ENVIO_EXPRESS = 300000;
    const int LIMITE_ITEMS = 5;

    const decimal COSTO_GRATIS = 0;
    const decimal COSTO_EXPRESS = 20000;
    const decimal COSTO_ESTANDAR = 10000;
    const decimal COSTO_EXTERIOR = 15000;

    // ============================
    // LISTAS (ALMACENAMIENTO)
    // ============================
    static List<decimal> listaMontos = new List<decimal>();
    static List<string> listaClientes = new List<string>();
    static List<int> listaItems = new List<int>();
    static List<string> listaCiudades = new List<string>();
    static List<string> listaCategorias = new List<string>();

    static void Main(string[] args)
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
    static int MostrarMenu()
    {
        Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Registrar pedido");
        Console.WriteLine("2. Ver reportes");
        Console.WriteLine("3. Salir");
        Console.Write("Seleccione una opción: ");

        return Convert.ToInt32(Console.ReadLine());
    }

    // ============================
    // REGISTRAR PEDIDO
    // ============================
   static void RegistrarPedido()
{
    Console.WriteLine("\n=== REGISTRO DE PEDIDO ===");

    decimal monto;
    while (true)
    {
        Console.Write("Monto del pedido: ");
        if (decimal.TryParse(Console.ReadLine(), out monto) && monto >= 0)
            break;
        else
            Console.WriteLine("Error: Ingrese un número válido.");
    }

    string ciudad;
    while (true)
    {
        Console.Write("Ciudad destino: ");
        ciudad = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(ciudad))
            break;
        else
            Console.WriteLine("Error: No puede estar vacío.");
    }

    string cliente;
    while (true)
    {
        Console.Write("Tipo de cliente (nuevo/recurrente): ");
        cliente = Console.ReadLine().ToLower();
        if (cliente == "nuevo" || cliente == "recurrente")
            break;
        else
            Console.WriteLine("Error: Escriba 'nuevo' o 'recurrente'.");
    }

    int items;
    while (true)
    {
        Console.Write("Cantidad de items: ");
        if (int.TryParse(Console.ReadLine(), out items) && items >= 0)
            break;
        else
            Console.WriteLine("Error: Ingrese un número entero válido.");
    }

    string categoria = CalcularCategoria(monto, cliente, items);

    listaMontos.Add(monto);
    listaClientes.Add(cliente);
    listaItems.Add(items);
    listaCiudades.Add(ciudad);
    listaCategorias.Add(categoria);

    Console.WriteLine($"Pedido registrado como: {categoria}");
}

    // ============================
    // LÓGICA DE NEGOCIO
    // ============================
    static string CalcularCategoria(decimal monto, string cliente, int items)
    {
        if (monto >= LIMITE_ENVIO_GRATIS && cliente == "recurrente")
        {
            return "Envío Gratis";
        }
        else if (items > LIMITE_ITEMS || monto >= LIMITE_ENVIO_EXPRESS)
        {
            return "Envío Express";
        }
        else
        {
            return "Envío Estándar";
        }
    }

    // ============================
    // REPORTES
    // ============================
    static void MostrarReportes()
    {
        Console.WriteLine("\n=== REPORTES ===");

        if (listaMontos.Count == 0)
        {
            Console.WriteLine("No hay pedidos registrados.");
            return;
        }

        int totalPedidos = listaMontos.Count;
        decimal suma = 0;

        int gratis = 0;
        int express = 0;
        int estandar = 0;

        foreach (var monto in listaMontos)
        {
            suma += monto;
        }

        foreach (var categoria in listaCategorias)
        {
            if (categoria == "Envío Gratis") gratis++;
            else if (categoria == "Envío Express") express++;
            else estandar++;
        }

        decimal promedio = suma / totalPedidos;

        Console.WriteLine($"Total pedidos: {totalPedidos}");
        Console.WriteLine($"Promedio de monto: {promedio}");
        Console.WriteLine($"Envíos Gratis: {gratis}");
        Console.WriteLine($"Envíos Express: {express}");
        Console.WriteLine($"Envíos Estándar: {estandar}");
    }
}
