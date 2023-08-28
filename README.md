# Ejercicio 02

## Respuestas de las preguntas enunciadas

### ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
- Por agregación: Cadete-Cadetería, Cadete-Pedido
- Por composición: Pedido-Cliente

### ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
- La clase Cadetería debería tener los siguientes métodos: MostrarInfo(), MostrarInfoCadetes(), ObtenerInforme(), MostrarInforme(), AsignarPedidoACadete(),
DarAltaPedido(), AgregarPedido(), CambiarEstadoPedido() (consultar), ReasignarPedidoAOtroCadete()
- La clase Cadete debería tener los siguiente métodos: JornalACobrar(), AsignarPedido(), EliminarPedido()

### Teniendo en cuenta los principios de abstracción y ocultamiento, qué atributos, propiedades y métodos deberían ser públicos y cuáles privados.´

### ¿Cómo diseñaría los constructores de cada una de las clases?
- Constructor de la clase Cadetería: `public Cadeteria(string nombre, string telefono)`
- Constructores de la clase Cadete: `public Cadete(int id, string nombre, string direccion, string telefono)`, `public Cadete(string id, string nombre, string direccion, string telefono)` (este último es por si el id se recibe como string)
- Constructores de la clase Pedido: `public Pedido(int nro, string observaciones, Cliente cl, EstadoPedido.Pendiente)`, `public Pedido(string nro, string observaciones, Cliente cl, EstadoPedido.Pendiente)`(este último es por si el número de pedido se recibe como string)
- Constructor de la clase Cliente: `public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)`

### ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?