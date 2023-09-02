namespace EmpresaDeCadeteria;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listaCadetes;
    private List<Pedido> listaPedidos;

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

    /*public bool AsignarPedidoACadete(int idCadete, Pedido pedidoTomado){
        bool pedidoAsignado = false;
        foreach( var c in listaCadetes){
            if(c.Id == idCadete){
                c.AgregarPedido(pedidoTomado);
                pedidoAsignado = true;
            } 
        }

        return pedidoAsignado; 
    }*/

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

    private int CantPedidosEntregadosCadete(int idCadete){
        int cant = 0;
        foreach(var p in listaPedidos){
            if((p.IdCadete() == idCadete) && (p.Estado == EstadoPedido.Entregado)) cant++;
        }

        return cant;
    }

    public double JornalACobrar(int idCadete){
        return ((double)500 * CantPedidosEntregadosCadete(idCadete));
    }

    /*public Informe CrearInforme(){
        List<int> idsCadetes = listaCadetes.Select(cad => cad.Id).ToList();
        List<string> nombresCadetes = listaCadetes.Select(cad => cad.Nombre).ToList();
        List<int> cantPedidosEntregadosCadetes = listaCadetes.Select(cad => cad.CantidadPedidosEntregados()).ToList();
        List<double> montosCadetes = listaCadetes.Select(cad => cad.JornalACobrar()).ToList();
        int totalPedidosEntregados = listaCadetes.Sum(cad => cad.CantidadPedidosEntregados());
        int cantPromedioDePedidosEntregados = (int)cantPedidosEntregadosCadetes.Average();

        Informe informe = new Informe(CantCadetes(), idsCadetes, nombresCadetes, cantPedidosEntregadosCadetes, montosCadetes, totalPedidosEntregados, cantPromedioDePedidosEntregados);
        return informe;
    }*/
}