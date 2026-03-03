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
