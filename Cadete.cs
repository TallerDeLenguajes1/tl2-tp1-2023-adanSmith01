namespace EmpresaDeCadeteria;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private int cantidadPedidosAsignados;
    private int cantidadPedidosEntregados;
    private List<Pedido> listaPedidos;
    
    public int Id{get => id;}
    public string Nombre{get => nombre;}
    public string Direccion{get => direccion;}
    public string Telefono{get => telefono;}
    public int CantidadPedidosAsignados{get => cantidadPedidosAsignados;}
    public List<Pedido> ListaPedidos{get => listaPedidos;}
    public int CantidadPedidosEntregados {get => cantidadPedidosEntregados;}

    public Cadete(int id, string nombre, string direccion, string telefono){
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        cantidadPedidosAsignados = 0;
        cantidadPedidosEntregados = 0;
        this.listaPedidos = new List<Pedido>();
    }

    public Cadete(string id, string nombre, string direccion, string telefono){
        this.id = Convert.ToInt32(id);
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.cantidadPedidosAsignados = 0;
        this.listaPedidos = new List<Pedido>();
    }

    public void AgregarPedido(Pedido pedido){
        listaPedidos.Add(pedido);
        cantidadPedidosAsignados++;
    }
    
    public bool CambiarEstadoPedido(int nroPedido){
        foreach(var p in listaPedidos){
            if(p.Nro == nroPedido){
                p.Entregado();
                cantidadPedidosEntregados++;
                return true;
            }
        }

        return false;
    }

    public void EliminarPedido(int nroPedido){
        Pedido pedidoAEliminar = new Pedido();
        foreach(var p in listaPedidos){
            if(p.Nro == nroPedido){
                pedidoAEliminar = p;
            }
        }

        if(pedidoAEliminar != null) listaPedidos.Remove(pedidoAEliminar);
    }

    public Pedido QuitarPedido(int nroPedido){
        Pedido pedidoAQuitar = listaPedidos.Find(p => p.Nro == nroPedido);
        
        if(pedidoAQuitar != null){
            listaPedidos.Remove(pedidoAQuitar);
        }

        return pedidoAQuitar;
    }

    public float JornalACobrar(){
        return(500 * cantidadPedidosEntregados);
    }
}