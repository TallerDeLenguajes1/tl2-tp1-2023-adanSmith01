namespace EmpresaDeCadeteria;

public enum EstadoPedido
{
    Aceptado,
    Pendiente,
    Rechazado
}

public class Pedido
{
    private int nro;
    private string observaciones;
    private EstadoPedido estado;
    private Cliente cliente;

    public int Nro{get => nro;}
    public string Observaciones{get => observaciones;}
    public EstadoPedido Estado{get => estado;}

    public Pedido(string observaciones, Cliente cliente){
        this.nro += 1;
        this.observaciones = observaciones;
        this.estado = EstadoPedido.Pendiente;
        this.cliente = new Cliente();
        this.cliente = cliente;
    } 
    public Pedido(string nro, string observaciones, EstadoPedido estado, Cliente cliente){
        this.nro = Convert.ToInt32(nro);
        this.observaciones = observaciones;
        this.estado = estado;
        this.cliente = cliente;
    } 

    public void VerDatosCliente(){
        Console.WriteLine("\n====== DATOS DEL CLIENTE ====\n");
        Console.WriteLine($"> Nombre: {cliente.Nombre}");
        Console.WriteLine($"> Direccion: {cliente.Direccion}");
    }
}