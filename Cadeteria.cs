namespace EmpresaDeCadeteria;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listaCadetes;
    private List<Pedido> listaPedidosAAsignar;

    public string Nombre{get => nombre;}
    public string Telefono{get => telefono;}
    public List<Cadete> ListaCadetes{set => listaCadetes = value;}


    public Cadeteria(){}
    public Cadeteria(string nombre, string telefono){
        this.nombre = nombre;
        this.telefono = telefono;
        this.listaPedidosAAsignar = new List<Pedido>();
    }

    public Pedido DarAltaPedido(){
        string nombreCliente = "", direccionCliente = "", telCliente = "", datosReferenciaCliente = "";
        string obsPedido = "";
        Console.WriteLine("\n$========= DATOS DEL CLIENTE ==========\n");
        Console.Write("> Nombre:");
        nombreCliente = Console.ReadLine();
        Console.Write("> Dirección: ");
        direccionCliente = Console.ReadLine();
        Console.Write("> Teléfono: ");
        telCliente = Console.ReadLine();
        Console.Write("> Datos de referencia de su dirección: ");
        datosReferenciaCliente = Console.ReadLine();
        Console.Write("\n> OBSERVACIONES SOBRE EL PEDIDO: ");
        obsPedido = Console.ReadLine();
        Cliente cl = new Cliente(nombreCliente, direccionCliente, telCliente, datosReferenciaCliente);
        Pedido ped = new Pedido(obsPedido, cl);

        return ped;    
    }

    public int CantidadPedidos(){
        return listaPedidosAAsignar.Count;
    }
    public void AgregarPedido(Pedido p){
        listaPedidosAAsignar.Add(p);
    }

    public void MostrarPedidos(){
        foreach(var p in listaPedidosAAsignar){
            Console.WriteLine($"> Nro: {p.Nro}");
            Console.WriteLine($"> Obs: {p.Observaciones}");
            p.VerDatosCliente();
        }
    }
}