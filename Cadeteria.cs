namespace EmpresaDeCadeteria;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listaCadetes;

    public string Nombre{get => nombre;}
    public string Telefono{get => telefono;}
    public List<Cadete> ListaCadetes{get => listaCadetes;}

    public Cadeteria(){}
    public Cadeteria(string nombre, string telefono){
        this.nombre = nombre;
        this.telefono = telefono;
    }

    private int CantCadetes(){
        return listaCadetes.Count;
    }

    public void AgregarListaCadetes(List<Cadete> listaCadetes){
        this.listaCadetes = listaCadetes;
    }

    public bool DarAltaPedido(int nroPedido, string obsPedido, int idCadete, string nombreCliente, string direccionCliente, string telCliente, string datosReferenciaDireccionCliente){
        Pedido ped = new Pedido(nroPedido, obsPedido, nombreCliente, direccionCliente, telCliente, datosReferenciaDireccionCliente);
        bool pedidoAsignado = AsignarPedidoACadete(idCadete, ped);
        return pedidoAsignado;

    }

    public int IdMaximo(){
        return (listaCadetes.Count - 1);
    }

    public bool AsignarPedidoACadete(int idCadete, Pedido pedidoTomado){
        bool pedidoAsignado = false;
        foreach( var c in listaCadetes){
            if(c.Id == idCadete){
                c.AgregarPedido(pedidoTomado);
                pedidoAsignado = true;
            } 
        }

        return pedidoAsignado; 
    }

    public bool CambiarEstadoPedido(int nroPedido){
        foreach (var cad in listaCadetes){
            if(cad.CambiarEstadoPedido(nroPedido)) {
                return true;
            }
        }

        return false;
    }

    public bool ReasignarPedidoACadete(int nroPedido, int idCadete){
        bool reasignacionRealizada = false;
        Pedido pedidoAReasignar = null;
        foreach(var cad in listaCadetes){
            pedidoAReasignar = cad.ListaPedidos.Find(p => p.Nro == nroPedido);
            if(pedidoAReasignar != null) {
                cad.ListaPedidos.Remove(pedidoAReasignar);
                break;
            }
        }

        if(pedidoAReasignar != null && pedidoAReasignar.Estado != EstadoPedido.Entregado){
            foreach(var cad in listaCadetes){
                if(cad.Id == idCadete){
                    cad.AgregarPedido(pedidoAReasignar);
                    reasignacionRealizada = true;
                    break;
                }
            }
        }

        return reasignacionRealizada;
    }

    public Informe CrearInforme(){
        List<int> idsCadetes = listaCadetes.Select(cad => cad.Id).ToList();
        List<string> nombresCadetes = listaCadetes.Select(cad => cad.Nombre).ToList();
        List<int> cantPedidosEntregadosCadetes = listaCadetes.Select(cad => cad.CantidadPedidosEntregados()).ToList();
        List<double> montosCadetes = listaCadetes.Select(cad => cad.JornalACobrar()).ToList();
        int totalPedidosEntregados = listaCadetes.Sum(cad => cad.CantidadPedidosEntregados());
        int cantPromedioDePedidosEntregados = (int)cantPedidosEntregadosCadetes.Average();

        Informe informe = new Informe(CantCadetes(), idsCadetes, nombresCadetes, cantPedidosEntregadosCadetes, montosCadetes, totalPedidosEntregados, cantPromedioDePedidosEntregados);
        return informe;
    }
}