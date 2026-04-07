# PROYECTO
Sistema De Clasificacion De Pedidos - ENTREGA 1 

INTEGRANTES:
- Luis Alfredo Romero Mendoza

PROBLEMA:
Una tienda en línea necesita un programa en C# que, a partir de los datos de un pedido, determine automáticamente la categoría de despacho y el costo de envío según reglas de negocio predefinidas.
El sistema evalúa condiciones relacionadas con monto del pedido, tipo de cliente, cantidad de ítems y ciudad destino.

IPO:
ENTRADAS:

  VARIABLES              TIPO               DESCRIPCION
- montoPedido          decimal           Valor Total Del Pedido
- ciudadDestino        string            Ciudad Del Envio
- tipoCliente          string            nuevo o recurrente
- cantidadItems        int               numero de productos

PROCESO:
- Si monto ≥ 150000 Y cliente recurrente → Envío Gratis.
- Si items > 5 O monto ≥ 300000 → Envío Express.
- En cualquier otro caso → Envío Estándar.
- Si ciudad es "exterior" → Se suma un costo adicional.

SALIDAS:
- Categoría de despacho
- Costo total de envío
- Mensaje contextual al usuario

  Variables utilizadas
       NOMBRE	          TIPO	         PROPOSITO
- montoPedido	         decimal	      Manejo preciso de dinero
- ciudadDestino	       string       	Determinar recargo adicional
- tipoCliente	         string	        Aplicar beneficio de envío gratis
- cantidadItems	       int	          Evaluar envío express
- categoriaDespacho	   string       	Resultado de clasificación
- costoEnvio	         decimal      	Valor final calculado

CASO DE PRUEBA:
Entrada:
- monto: 160000
- cliente: recurrente
- items: 2
- ciudad: medellin

Resultado esperado:

- Envío Gratis
- Costo: 0

CASO BORDE:
Entrada:
- monto: 150000
- cliente: recurrente
- items: 1
- ciudad: exterior

Resultado esperado:

- Envío Gratis
- Costo: 15000 (recargo exterior)


INSTRUCCIONES PARA EJECUTAR
- Abrir proyecto en Visual Studio Code.
Ejecutar:
- run
- Ingresar los datos solicitados en consola.

Sistema De Clasificación De Pedidos - ENTREGA 2

PROBLEMA:
- El sistema evoluciona respecto a la Entrega 1, permitiendo registrar varios pedidos en una sola ejecución, almacenarlos en listas y generar reportes a partir de la información ingresada. Además, se implementan validaciones para evitar errores en la entrada de datos.

IPO:
ENTRADAS:
VARIABLES     	TIPO	       DESCRIPCIÓN
montoPedido	    decimal	   Valor Total Del Pedido
ciudadDestino	  cadena	   Ciudad Del Envío
tipoCliente	    cadena	   nuevo o recurrente
cantidadItems 	int	       número de productos

PROCESO:
- Se implementa un menú interactivo que permite al usuario:
- Registrar múltiples pedidos
- Generar reportes

Reglas de negocio:

Si monto ≥ 150000 Y cliente recurrente → Envío Gratis
Si artículos > 5 O monto ≥ 300000 → Envío Express
En cualquier otro caso → Envío Estándar

Adicional:
- Los datos se almacenan en listas (List<T>) 
- se recorren mediante ciclos foreach para generar reportes
- Se validan las entradas para evitar errores del sistema

SALIDAS:
- Categoría de despacho por pedido
- Total de pedidos registrados
- Promedio de montos
- Cantidad de envíos por categoría
- Mensajes informativos al usuario

VARIABLES UTILIZADAS:
NOMBRE	TIPO	PROPOSITO
listaMontos	List<decimal>	Almacenar montos de pedidos
listaClientes	List<string>	Guardar tipo de cliente
listaItems	List<int>	Cantidad de productos
listaCiudades	List<string>	Ciudad destino
listaCategorias	List<string>	Clasificación de envío

CASO DE PRUEBA:
Entrada:

monto: 200000
cliente: recurrente
artículos: 3
ciudad: medellín

Resultado esperado:

Envío gratis

CASO BORDE:
Entrada:

monto: 150000
cliente: recurrente
artículos: 1
ciudad: medellín

Resultado esperado:

Envío gratis

CASO INVÁLIDO:
Entrada:

monto: abc

Resultado:

El sistema solicita nuevamente el dato hasta que sea válido

VALIDACIONES IMPLEMENTADAS:
Uso de TryParse para evitar errores
Control de datos vacíos
Restricción de valores negativos
Validación de tipo de cliente
Control de opciones inválidas en el menú

Esto permite que el sistema no falle durante la ejecución.

INSTRUCCIONES PARA EJECUTAR

Abrir proyecto en Visual Studio Code.

Ejecutar:

dotnet run

Ingresar los datos solicitados en consola.
