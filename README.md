# Ejercicio 02

## Respuestas de las preguntas enunciadas

### ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
- Por agregación: Cadete-Cadetería, Cadete-Pedido
- Por composición: Pedido-Cliente

### ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
- La clase Cadetería debería tener los siguientes métodos: 
  - DarAltaPedido(),
  - AsignarPedidoACadete(), 
  - MostrarInforme(), 
  - MostrarCantidadDePedidosDeCadetes(), 
  - CambiarEstadoPedido(),
  - ReasignarPedidoAOtroCadete()
- La clase Cadete debería tener los siguiente métodos: 
   - JornalACobrar(), 
   - AgregarPedido(),
   - CambiarEstadoPedido(), 
   - EliminarPedido(),
   - QuitarPedido()

### Teniendo en cuenta los principios de abstracción y ocultamiento, qué atributos, propiedades y métodos deberían ser públicos y cuáles privados.´

- De la clase Cliente:
  - Los datos personales (nombre, direccion, telefono) como atributos privados y accedidos usando la propiedad `get`
- De la clase Pedido:
  - Sus datos principales como atributos privados y solo tener acceso a la información, por medio de la propiedad`get`, relacionada al número, observaciones y estado de cada pedido. Por otro lado, los métodos `VerDatosCliente()` y `Entregado()` deben ser públicos.
- De la clase Cadete:
  - Sus datos personales (nombre, direccion, telefono) quedan como atributos privados y pueden ser accedidos con el método público `VerDatosCadete()`. Los métodos nombrados en el enunciado anterior serían públicos.

### ¿Cómo diseñaría los constructores de cada una de las clases?
- Constructor de la clase Cadetería: `public Cadeteria(string nombre, string telefono)`
- Constructores de la clase Cadete:  `public Cadete(string id, string nombre, string direccion, string telefono)`
- Constructores de la clase Pedido: `public Pedido(int nro, string observaciones, string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferenciaDireccionCliente)`
- Constructor de la clase Cliente: `public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)`
