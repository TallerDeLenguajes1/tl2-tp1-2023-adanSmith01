namespace EmpresaDeCadeteria;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listaCadetes;

    public string Nombre{get => nombre;}
    public string Telefono{get => telefono;}
    public List<Cadete> ListaCadetes{get => listaCadetes; set => listaCadetes = value;}

    public Cadeteria(){}
    public Cadeteria(string nombre, string telefono){
        this.nombre = nombre;
        this.telefono = telefono;
    }

    public void AgregarListaCadetes(List<Cadete> listaCadetes){
        this.listaCadetes = listaCadetes;
    }

    public Pedido DarAltaPedido(int nroPedido){
        string nombreCliente = "", direccionCliente = "", telCliente = "", datosReferenciaDireccionCliente = "";
        string obsPedido = "";
        Console.WriteLine("\n$========= DATOS DEL CLIENTE ==========\n");
        Console.Write("> Nombre:");
        nombreCliente = Console.ReadLine();
        Console.Write("> Dirección: ");
        direccionCliente = Console.ReadLine();
        Console.Write("> Teléfono: ");
        telCliente = Console.ReadLine();
        Console.Write("> Datos de referencia de su dirección: ");
        datosReferenciaDireccionCliente = Console.ReadLine();
        Console.Write("\n> OBSERVACIONES SOBRE EL PEDIDO: ");
        obsPedido = Console.ReadLine();
        Pedido ped = new Pedido(nroPedido, obsPedido, nombreCliente, direccionCliente, telCliente, datosReferenciaDireccionCliente);

        return ped;
    }

    public int IdMaximo(){
        return (listaCadetes.Count - 1);
    }

    public void AsignarPedidoACadete(int idCadete, Pedido pedidoTomado){
        foreach( var c in listaCadetes){
            if(c.Id == idCadete) c.AgregarPedido(pedidoTomado);
        }
        
    }

    public void MostrarCantidadDePedidosDeCadetes(){
        Console.WriteLine("\n============ CANTIDAD DE PEDIDOS POR CADETE ==============\n");
        foreach(var cad in listaCadetes){
            Console.WriteLine($"Id: {cad.Id}       Nombre: {cad.Nombre}      Cant. pedidos: {cad.CantidadPedidosAsignados}");
        }
    }

    public bool CambiarEstadoPedido(int nroPedido){
        foreach (var cad in listaCadetes){
            if(cad.CambiarEstadoPedido(nroPedido)) {
                Console.WriteLine("\nSe cambió el estado del pedido.\n");
                return true;
            }
        }

        return false;
    }

    public void ReasignarPedidoACadete(int nroPedido, int idCadete){
        Pedido pedidoAReasignar = new Pedido();
        foreach(var cad in listaCadetes){
            pedidoAReasignar = cad.ListaPedidos.Find(p => p.Nro == nroPedido);
            if(pedidoAReasignar != null) {
                cad.ListaPedidos.Remove(pedidoAReasignar);
                break;
            }
        }

        if(pedidoAReasignar.Estado == EstadoPedido.Entregado){
            Console.WriteLine("\nNo se puede reasignar un pedido que ya ha sido entregado.\n");
        } else{
            foreach(var cad in listaCadetes){
            if(cad.Id == idCadete){
                cad.AgregarPedido(pedidoAReasignar);
                break;
            }
        }
        }
    }

    public void MostrarInforme(){
        Console.WriteLine("\n=========== INFORME DEL DÍA ============\n");
        int cantTotalPedidos = listaCadetes.Sum(x => x.CantidadPedidosEntregados);
        foreach(var c in listaCadetes){
            Console.WriteLine($"Nombre: {c.Nombre}     Cant. Pedidos Entregados: {c.CantidadPedidosEntregados}   Monto ganado: {c.JornalACobrar()}");
        }
        Console.WriteLine($"\nCantidad total de pedidos entregados: {cantTotalPedidos}");
    }
}