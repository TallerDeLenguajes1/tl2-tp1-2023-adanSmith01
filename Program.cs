using EmpresaDeCadeteria;

internal class Program
{
    private static void Main(string[] args)
    {
        AccesoDatosCadeteria acceso;
        Cadeteria oca;
        List<Cadete> listaCadetes;
        string acceder = "";
        string rutaArchivoDatosCadeteria = "", rutaArchivoDatosCadetes = "";

        do{
            Console.WriteLine("TIPO DE ACCESO A LOS DATOS\n");
            Console.WriteLine("> Opción a: Por archivo csv");
            Console.WriteLine("> Opción b: Por archivo json\n");
            Console.Write("Opcion: ");
            acceder = Console.ReadLine();
        }while(acceder != "a" && acceder != "b");

        if(acceder == "a"){
            rutaArchivoDatosCadeteria = "datosCadeteria.csv";
            rutaArchivoDatosCadetes = "datosCadetes.csv";
            acceso = new AccesoCSV();
        } else{
            rutaArchivoDatosCadeteria = "cadeteriaInfo.json";
            rutaArchivoDatosCadetes = "cadetesInfo.json";
            acceso = new AccesoJSON();
        }

        if(acceso.ExisteArchivoDatos(rutaArchivoDatosCadeteria) && acceso.ExisteArchivoDatos(rutaArchivoDatosCadetes)){
            oca = acceso.ObtenerInfoCadeteria(rutaArchivoDatosCadeteria);
            listaCadetes = acceso.ObtenerListaCadetes(rutaArchivoDatosCadetes);
            oca.AgregarListaCadetes(listaCadetes);

            //INTERFAZ
            string nombreCliente = "", direccionCliente = "", telCliente = "", datosReferenciaDireccionCliente = "";
            string obsPedido = "";
            string operacion = "";
            int nroPedido = 0;

            do{
                Console.WriteLine("================ SISTEMA DE GESTIÓN DE PEDIDOS DE OCA ================\n");
                Console.WriteLine("a - Dar de alta pedido.\n");
                Console.WriteLine("b - Asignar cadete a pedido\n");
                Console.WriteLine("c - Cambiar estado de pedido.\n");
                Console.WriteLine("d - Reasignar pedido a otro cadete.\n");
                Console.WriteLine("e - Salir.\n");
                Console.Write("Elija la operación: ");
                operacion = Console.ReadLine();
                
                switch(operacion){
                    case "a":
                    nroPedido++;
                    Console.WriteLine("\n$========= DATOS DEL CLIENTE ==========\n");
                    Console.Write("> Nombre: ");
                    nombreCliente = Console.ReadLine();
                    Console.Write("> Dirección: ");
                    direccionCliente = Console.ReadLine();
                    Console.Write("> Teléfono: ");
                    telCliente = Console.ReadLine();
                    Console.Write("> Datos de referencia de su dirección: ");
                    datosReferenciaDireccionCliente = Console.ReadLine();
                    Console.Write("\n> OBSERVACIONES SOBRE EL PEDIDO: ");
                    obsPedido = Console.ReadLine();
                    Console.WriteLine("\n========INFORMACIÓN DEL PEDIDO========\n");
                    Console.WriteLine($"\nNro: {nroPedido}");
                    Console.WriteLine($"Obs: {obsPedido}");

                    if(oca.DarAltaPedido(nroPedido, obsPedido, nombreCliente, direccionCliente, telCliente, datosReferenciaDireccionCliente)) Console.WriteLine("\nEl pedido fue dado de alta exitosamente.\n");
                    break;

                    case "b":
                    int idCadete = 0, nroPed = 0;
                    string idCad = "", nro = "";

                    do{
                        MostrarCantidadDePedidosDeCadetes(oca);
                        Console.Write("Ingrese número de pedido: ");
                        nro = Console.ReadLine();
                        Console.Write("Ingrese id del cadete: ");
                        idCad = Console.ReadLine();

                        if(!int.TryParse(nro, out nroPed) || !int.TryParse(idCad, out idCadete)){
                            Console.WriteLine("\nERROR. Dato/s inválido/s\n");
                        } else{
                            if(idCadete < 0 || idCadete > oca.IdMaximo()){
                                Console.WriteLine("ERROR. Id inexistente");
                            } else{
                                if(oca.AsignarCadeteAPedido(idCadete, nroPed)) Console.WriteLine("\nAsignación realzada.\n");
                            }
                        }
                    }while(!int.TryParse(nro, out nroPed) || !int.TryParse(idCad, out idCadete) || (idCadete < 0 || idCadete > oca.IdMaximo()));
                    break;

                    case "c":
                    int numPedidoACambiar;
                    string numPedido = "";

                    do{
                        Console.Write("\nIngrese el número del pedido para cambiar de estado: ");
                        numPedido = Console.ReadLine();
                        if(!int.TryParse(numPedido, out numPedidoACambiar)){
                            Console.WriteLine("ERROR. Dato inválido.\n");
                        } else{
                            if(!oca.CambiarEstadoPedido(numPedidoACambiar)){
                                Console.WriteLine("\nERROR. No se pudo cambiar el estado del pedido.\n");
                            } else{
                                Console.WriteLine("\nSe cambió el estado del pedido.\n");
                            }
                        }
                    }while(!int.TryParse(numPedido, out numPedidoACambiar));
                    break;

                    case "d":
                    int nroPedidoAReasignar, idCadeteAReasignar;
                    string nroP = "", id = "";

                    do{
                        Console.Write("Ingrese número del pedido: ");
                        nroP = Console.ReadLine();
                        Console.Write("Ingrese id del cadete a reasignar pedido: ");
                        id = Console.ReadLine();

                        if(!int.TryParse(nroP, out nroPedidoAReasignar) || !int.TryParse(id, out idCadeteAReasignar)){
                            Console.WriteLine("\nERROR. El id o el número de pedido no es válido");
                        } else{
                            if(idCadeteAReasignar < 0 || idCadeteAReasignar > oca.IdMaximo()){
                                Console.WriteLine("ERROR. Id inexistente.");
                            } else{
                                if(!oca.ReasignarPedidoACadete(nroPedidoAReasignar, idCadeteAReasignar)){
                                    Console.WriteLine("\nNo se puede reasignar un pedido ya entregado.\n");
                                } else{
                                    Console.WriteLine("\nReasignación completada.\n");
                                }
                            }
                        }
                    }while(!int.TryParse(nroP, out nroPedidoAReasignar) || !int.TryParse(id, out idCadeteAReasignar) || (idCadeteAReasignar < 0 || idCadeteAReasignar > oca.IdMaximo()));
                    break;
                }
            }while(operacion != "e");

            Informe informe = oca.CrearInforme();
            MostrarInforme(informe);
        } else{
            Console.WriteLine("\nERROR. No existen los archivos con los datos iniciales.\n");
        }

        
    }

    private static void MostrarCantidadDePedidosDeCadetes(Cadeteria c){
        Console.WriteLine("\n============ CANTIDAD DE PEDIDOS POR CADETE ==============\n");
        foreach(var cad in c.ListaCadetes){
            Console.WriteLine($"Id: {cad.Id}       Nombre: {cad.Nombre}      Cant. pedidos: {c.CantPedidosCadete(cad.Id, EstadoPedido.Pendiente)}");
        }
        Console.WriteLine("\n");
    }

    private static void MostrarInforme(Informe informe){
        Console.WriteLine("\n===================== INFORME =====================\n");
        Console.WriteLine($"Cantidad de cadetes: {informe.CantCadetes}");
        Console.WriteLine($"\nId          Nombre              Cant. Pedidos Entregados        Monto ganado\n");
        for(int i = 0; i < informe.CantCadetes; i++){
            Console.WriteLine($"{informe.IdsCadetes[i]}        {informe.NombresCadetes[i]}                {informe.CantPedidosEntregadosCadetes[i]}                   {informe.MontosCadetes[i]}");
        }
        Console.WriteLine($"\nTotal de pedidos entregados: {informe.TotalPedidosEntregados}");
        Console.WriteLine($"\nCantidad promedio de pedidos entregados por cadete: {informe.CantPromedioDePedidosEntregados}");
    }
}
