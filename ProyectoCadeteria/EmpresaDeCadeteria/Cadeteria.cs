namespace EmpresaDeCadeteria;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listaCadetes;
    private List<Pedido> listaPedidos;

    public string Nombre{get => nombre; set => nombre = value;}
    public string Telefono{get => telefono; set => telefono = value;}
    public List<Cadete> ListaCadetes{get => listaCadetes;}

    public Cadeteria(string nombre, string telefono){
        this.nombre = nombre;
        this.telefono = telefono;
        this.listaPedidos = new List<Pedido>();
    }

    private int CantCadetes(){
        return listaCadetes.Count;
    }

    public bool TienePedidos(){
        return (listaPedidos.Count > 0);
    }
    public void AgregarListaCadetes(List<Cadete> listaCadetes){
        this.listaCadetes = listaCadetes;
    }

    public bool AgregarPedidoALista(Pedido ped){
        bool agregado = false;

        if(ped != null){
            listaPedidos.Add(ped);
            agregado = true;
        }

        return agregado;
    }

    public bool DarAltaPedido(int nroPedido, string obsPedido, string nombreCliente, string direccionCliente, string telCliente, string datosReferenciaDireccionCliente){
        Pedido ped = new Pedido(nroPedido, obsPedido, nombreCliente, direccionCliente, telCliente, datosReferenciaDireccionCliente);
        bool pedidoAgregado = AgregarPedidoALista(ped);
        return pedidoAgregado;

    }

    public int IdMaximo(){
        return (listaCadetes.Count - 1);
    }

    public bool AsignarCadeteAPedido(int idCadete, int nroPedido){
        bool asignacionRealizada = false;
        Cadete cad = listaCadetes.Find(x => x.Id == idCadete);

        if(cad != null){
            foreach(var p in listaPedidos){
                if(p.Nro == nroPedido){
                    p.VincularCadete(cad);
                    break;
                }
            }
            asignacionRealizada = true;
        }

        return asignacionRealizada;
    }

    public bool CambiarEstadoPedido(int nroPedido){
        foreach (var p in listaPedidos){
            if(p.Nro == nroPedido) {
                p.Entregado();
                return true;
            }
        }

        return false;
    }

    public bool ReasignarPedidoACadete(int nroPedido, int idCadete){
        bool reasignacionRealizada = false;
        Cadete cad = listaCadetes.Find(cadete => cadete.Id == idCadete);

        if(cad != null){
            foreach(var p in listaPedidos){
                if(p.Nro == nroPedido && p.Estado != EstadoPedido.Entregado){
                    p.VincularCadete(cad);
                }
                reasignacionRealizada = true;
            }
        }

        return reasignacionRealizada;
    }

    public int CantPedidosCadete(int idCadete, EstadoPedido estado){
        int cant = 0;
        foreach(var p in listaPedidos){
            if((p.ExisteCadete()) && (p.IdCadete() == idCadete) && (p.Estado == estado)) cant++;
        }

        return cant;
    }

    public double JornalACobrar(int idCadete){
        return ((double)500 * CantPedidosCadete(idCadete, EstadoPedido.Entregado));
    }

    public Informe CrearInforme(){
        List<int> idsCadetes = listaCadetes.Select(cad => cad.Id).ToList();
        List<string> nombresCadetes = listaCadetes.Select(cad => cad.Nombre).ToList();

        List<int> cantPedidosEntregadosCadetes = new List<int>();
        List<double> montosCadetes = new List<double>();
        foreach(var cad in listaCadetes){
            cantPedidosEntregadosCadetes.Add(CantPedidosCadete(cad.Id, EstadoPedido.Entregado));
            montosCadetes.Add(JornalACobrar(cad.Id));
        }
        
        int totalPedidosEntregados = cantPedidosEntregadosCadetes.Sum();
        int cantPromedioDePedidosEntregados = (int)cantPedidosEntregadosCadetes.Average();

        Informe informe = new Informe(CantCadetes(), idsCadetes, nombresCadetes, cantPedidosEntregadosCadetes, montosCadetes, totalPedidosEntregados, cantPromedioDePedidosEntregados);
        return informe;
    }
}