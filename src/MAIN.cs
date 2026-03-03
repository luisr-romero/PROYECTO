using System;

	public class Program
	{
		public static void Main(string[] args)
		{
			// ============================
        // DECLARACIÓN DE VARIABLES
        // ============================

        // decimal para dinero (mayor precisión en valores monetarios)
        decimal montoPedido;

        // string para datos textuales
        string ciudadDestino;
        string tipoCliente;

        // int para cantidades enteras
        int cantidadItems;

        // Variables de salida
        string categoriaDespacho;
        decimal costoEnvio = 0;

        // ============================
        // ENTRADA DE DATOS
        // ============================

        Console.WriteLine("=== SISTEMA DE CLASIFICACIÓN DE PEDIDOS ===");

        Console.Write("Ingrese el monto del pedido: ");
        montoPedido = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Ingrese la ciudad destino: ");
        ciudadDestino = Console.ReadLine();

        Console.Write("Ingrese el tipo de cliente (nuevo / recurrente): ");
        tipoCliente = Console.ReadLine().ToLower();

        Console.Write("Ingrese la cantidad de items: ");
        cantidadItems = Convert.ToInt32(Console.ReadLine());

        // ============================
        // LÓGICA PRINCIPAL
        // ============================

        /*
         Orden de evaluación de reglas:
         1. Envío gratis (prioridad más alta)
         2. Envío express
         3. Envío estándar (caso por defecto)
        */

        // REGLA 1: Envío gratis
        if (montoPedido >= 150000 && tipoCliente == "recurrente")
        {
            categoriaDespacho = "Envío Gratis";
            costoEnvio = 0;
        }
        // REGLA 2: Envío express
        else if (cantidadItems > 5 || montoPedido >= 300000)
        {
            categoriaDespacho = "Envío Express";
            costoEnvio = 20000;
        }
        // REGLA 3: Envío estándar
        else
        {
            categoriaDespacho = "Envío Estándar";
            costoEnvio = 10000;
        }

        // ============================
        // REGLA ADICIONAL
        // ============================

        // Si la ciudad es "exterior", se agrega un costo adicional
        if (ciudadDestino == "exterior")
        {
            costoEnvio = costoEnvio + 15000; // operador aritmético +
        }

        // ============================
        // SALIDA DE INFORMACIÓN
        // ============================

        Console.WriteLine("\n=== RESULTADO DEL PEDIDO ===");
        Console.WriteLine($"Categoría de despacho: {categoriaDespacho}");
        Console.WriteLine($"Costo total de envío: ${costoEnvio}");
        Console.WriteLine("Gracias por utilizar el sistema.");
    }
}
