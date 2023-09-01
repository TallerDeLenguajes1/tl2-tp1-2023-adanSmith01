using EmpresaDeCadeteria;

internal class Program
{
    private static void Main(string[] args)
    {
        string rutaArchivoDatosCadeteria = "datosCadeteria.csv";
        string rutaArchivoDatosCadetes = "datosCadetes.csv";

        Cadeteria oca = AccesoDatosCadeteria.ObtenerInfoCadeteria(rutaArchivoDatosCadeteria); //Verificado
        List<Cadete> listadoCadetes = AccesoDatosCadeteria.ObtenerListaCadetes(rutaArchivoDatosCadetes);
        oca.AgregarListaCadetes(listadoCadetes);

        //INTERFAZ
        string operacion = "";
        Pedido p = new Pedido();
        int nroPedido = 0;

        do{
            Console.WriteLine("================ SISTEMA DE GESTIÓN DE PEDIDOS DE OCA ================\n");
            Console.WriteLine("a - Dar de alta pedido.\n");
            Console.WriteLine("b - Asignar pedido a cadete.\n");
            Console.WriteLine("c - Cambiar estado de pedido.\n");
            Console.WriteLine("d - Reasignar pedido a otro cadete.\n");
            Console.WriteLine("e - Salir.\n");
            Console.Write("Elija la operación: ");
            operacion = Console.ReadLine();

            switch(operacion){
                case "a":
                nroPedido++;
                p = oca.DarAltaPedido(nroPedido);
                Console.WriteLine("\nEl pedido ha sido dado de alta exitosamente.\n");
                break;

                case "b":
                if(p != null){
                    int idCadete = 0;
                    string id = "";
                    int referencia = oca.IdMaximo();

                    do{
                        oca.MostrarCantidadDePedidosDeCadetes();
                        Console.Write("Ingrese el id del cadete para asignarle el pedido: ");
                        id = Console.ReadLine();
                        if(!int.TryParse(id, out idCadete)){
                            Console.WriteLine("\nError. Dato inválido.\n");
                        } else{
                            if(idCadete < 0 || idCadete > referencia){
                                Console.WriteLine("\nERROR. Id no existente.\n");
                            }
                        }
                    }while(!int.TryParse(id, out idCadete) || (idCadete < 0 || idCadete > referencia));

                    oca.AsignarPedidoACadete(idCadete, p);

                    Console.WriteLine("\nEl pedido fue asignado con éxito.\n");
                    p = null;
                }
                break;

                case "c":
                int nroPedidoACambiar;
                string nro = "";

                do{
                    Console.Write("\nIngrese el id del pedido para cambiar de estado: ");
                    nro = Console.ReadLine();
                    if(!int.TryParse(nro, out nroPedidoACambiar)){
                        Console.WriteLine("ERROR. Dato inválido.\n");
                    } else{
                        if(!oca.CambiarEstadoPedido(nroPedidoACambiar)){
                            Console.WriteLine("\nERROR. No se pudo cambiar el estado del pedido.\n");
                        }
                    }
                }while(!int.TryParse(nro, out nroPedidoACambiar));
                break;

                case "d":
                int nroPedidoAReasignar, idCadeteAReasignar;
                string nroP = "", idCad = "";

                do{
                    Console.Write("Ingrese numero del pedido: ");
                    nroP = Console.ReadLine();
                    Console.Write("Ingrese id del cadete a reasignar pedido: ");
                    idCad = Console.ReadLine();

                    if(!int.TryParse(nroP, out nroPedidoAReasignar) || !int.TryParse(idCad, out idCadeteAReasignar)){
                        Console.WriteLine("\nERROR. El id o el numero de pedido no es válido");
                    } else{
                        if(idCadeteAReasignar < 0 || idCadeteAReasignar > oca.IdMaximo()){
                            Console.WriteLine("ERROR. Id inexistente.");
                        } else{
                            oca.ReasignarPedidoACadete(nroPedidoAReasignar, idCadeteAReasignar);
                        }
                    }
                }while(!int.TryParse(nroP, out nroPedidoAReasignar) || !int.TryParse(idCad, out idCadeteAReasignar) || (idCadeteAReasignar < 0 || idCadeteAReasignar > oca.IdMaximo()));
                break;
            }
        }while(operacion != "e");
        oca.MostrarInforme();
    }

}