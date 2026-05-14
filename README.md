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

Sistema De Clasificación De Pedidos - ENTREGA 3
INTEGRANTES:

Luis Alfredo Romero Mendoza

PROBLEMA:

El sistema de clasificación de pedidos evoluciona respecto a las entregas anteriores, implementando una arquitectura modular basada en funciones con responsabilidad única. El programa permite registrar múltiples pedidos, almacenarlos dinámicamente y generar reportes estadísticos, manteniendo separada la lógica de negocio, la entrada/salida de datos y la orquestación general del sistema.

Además, se incorporan validaciones robustas para evitar errores de ejecución y documentación XML (///) en las funciones principales, permitiendo una mejor comprensión, mantenimiento y escalabilidad del código.

IPO:
ENTRADAS:
VARIABLES	TIPO	DESCRIPCIÓN
montoPedido	decimal	Valor total del pedido
ciudadDestino	string	Ciudad de envío
tipoCliente	string	Nuevo o recurrente
cantidadItems	int	Número de productos
PROCESO:

El sistema implementa una arquitectura modular organizada mediante funciones independientes.

FUNCIONES PRINCIPALES:
FUNCIÓN	RESPONSABILIDAD
EjecutarSistema()	Controlar el flujo principal
MostrarMenu()	Mostrar el menú interactivo
RegistrarPedido()	Coordinar el registro de pedidos
LeerMonto()	Validar monto
LeerCiudad()	Validar ciudad
LeerTipoCliente()	Validar tipo de cliente
LeerCantidadItems()	Validar cantidad de artículos
CalcularCategoria()	Aplicar reglas de negocio
GuardarPedido()	Almacenar información
MostrarReportes()	Mostrar estadísticas
ObtenerTotalPedidos()	Obtener total de registros
CalcularPromedioMontos()	Calcular promedio
ContarCategoria()	Contar pedidos por categoría
REGLAS DE NEGOCIO:
Si monto ≥ 150000 y cliente recurrente → Envío Gratis
Si artículos > 5 o monto ≥ 300000 → Envío Express
En cualquier otro caso → Envío Estándar
ARQUITECTURA DEL SISTEMA:

El proyecto se encuentra dividido en módulos funcionales:

ORQUESTACIÓN

Controla el flujo general del sistema y coordina las operaciones principales.

ENTRADA Y SALIDA (UI)

Funciones encargadas de:

Mostrar mensajes
Solicitar información
Validar datos
Mostrar reportes
LÓGICA DE NEGOCIO

Funciones que:

Procesan información
Calculan categorías
Generan estadísticas
ALMACENAMIENTO

Uso de listas (List<T>) para almacenar dinámicamente los pedidos registrados.

VALIDACIONES IMPLEMENTADAS:
Uso de TryParse
Validación de datos vacíos
Restricción de números negativos
Validación del tipo de cliente
Validación de opciones del menú
Prevención de colapsos por excepciones

Estas validaciones garantizan que el sistema no falle durante la ejecución.

SALIDAS:
Categoría de despacho
Total de pedidos registrados
Promedio de montos
Cantidad de pedidos por categoría
Mensajes informativos al usuario
VARIABLES UTILIZADAS:
NOMBRE	TIPO	PROPÓSITO
listaMontos	List<decimal>	Almacenar montos
listaClientes	List<string>	Guardar tipos de cliente
listaItems	List<int>	Guardar cantidad de productos
listaCiudades	List<string>	Guardar ciudades destino
listaCategorias	List<string>	Guardar clasificación de envío
CASO DE PRUEBA:
Entrada:
monto: 200000
cliente: recurrente
artículos: 3
ciudad: medellín
Resultado esperado:
Envío Gratis
CASO BORDE:
Entrada:
monto: 150000
cliente: recurrente
artículos: 1
ciudad: medellín
Resultado esperado:
Envío Gratis
CASO INVÁLIDO:
Entrada:
monto: abc
Resultado esperado:
El sistema solicita nuevamente el dato hasta que sea válido.
FLUJO GENERAL DEL SISTEMA:
Main
 ↓
EjecutarSistema
 ↓
MostrarMenu
 ↓
RegistrarPedido
 ↓
Funciones de validación
 ↓
CalcularCategoria
 ↓
GuardarPedido
 ↓
MostrarReportes
DOCUMENTACIÓN IMPLEMENTADA:

El sistema utiliza documentación XML (///) en las funciones principales mediante:

<summary>
<param>
<returns>

Esto permite mejorar la comprensión, mantenimiento y documentación técnica del proyecto.

INSTRUCCIONES PARA EJECUTAR
Abrir el proyecto en Visual Studio Code.
Abrir la terminal.
Ejecutar:
dotnet run
Ingresar los datos solicitados en consola.
CONCLUSIÓN

Durante las tres entregas el sistema evolucionó progresivamente:

Entrega 1: lógica básica y condicionales
Entrega 2: múltiples registros, listas y ciclos
Entrega 3: arquitectura modular, funciones especializadas y documentación técnica

El proyecto final implementa principios de organización y modularidad, separando responsabilidades y mejorando la mantenibilidad del código.
