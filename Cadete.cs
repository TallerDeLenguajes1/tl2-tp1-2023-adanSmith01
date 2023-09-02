namespace EmpresaDeCadeteria;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listaPedidos;
    
    public int Id{get => id;}
    public string Nombre{get => nombre;}
    public string Direccion{get => direccion;}
    public string Telefono{get => telefono;}
    public List<Pedido> ListaPedidos{get => listaPedidos;}

    public Cadete(int id, string nombre, string direccion, string telefono){
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.listaPedidos = new List<Pedido>();
    }

    public Cadete(string id, string nombre, string direccion, string telefono){
        this.id = Convert.ToInt32(id);
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.listaPedidos = new List<Pedido>();
    }

    public void AgregarPedido(Pedido pedido){
        listaPedidos.Add(pedido);
    }
    
    public bool CambiarEstadoPedido(int nroPedido){
        foreach(var p in listaPedidos){
            if(p.Nro == nroPedido){
                p.Entregado();
                return true;
            }
        }

        return false;
    }

    public int CantPedidosPendientes(){
        int cantPedidosPendientes = 0;
        foreach(var p in listaPedidos){
            if(p.Estado == EstadoPedido.Pendiente) cantPedidosPendientes++;
        }

        return cantPedidosPendientes;
    }

    public int CantidadPedidosEntregados(){
        int cantPedidosEntregados = 0;
        foreach(var p in listaPedidos){
            if(p.Estado == EstadoPedido.Entregado) cantPedidosEntregados++;
        }

        return cantPedidosEntregados;
    }

    public double JornalACobrar(){
        return((double)500 * CantidadPedidosEntregados());
    }
}