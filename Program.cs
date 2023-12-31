﻿using EmpresaDeCadeteria;

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
        string nombreCliente = "", direccionCliente = "", telCliente = "", datosReferenciaDireccionCliente = "";
        string obsPedido = "";
        string operacion = "";
        int nroPedido = 0;

        do{
            Console.WriteLine("================ SISTEMA DE GESTIÓN DE PEDIDOS DE OCA ================\n");
            Console.WriteLine("a - Dar de alta pedido.\n");
            Console.WriteLine("b - Cambiar estado de pedido.\n");
            Console.WriteLine("c - Reasignar pedido a otro cadete.\n");
            Console.WriteLine("d - Salir.\n");
            Console.Write("Elija la operación: ");
            operacion = Console.ReadLine();
            
            switch(operacion){
                case "a":
                int idCadete = 0;
                string idCad = "";
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
                Console.WriteLine($"\nN pedido: {nroPedido}\n");
                MostrarCantidadDePedidosDeCadetes(oca);
                do{
                    Console.Write("Ingresar id del cadete a asignar: ");
                    idCad = Console.ReadLine();
                }while(!int.TryParse(idCad, out idCadete) || (idCadete < 0 || idCadete > oca.IdMaximo()));

                if(oca.DarAltaPedido(nroPedido, obsPedido, idCadete, nombreCliente, direccionCliente, telCliente, datosReferenciaDireccionCliente)) Console.WriteLine("\nEl pedido fue dado de alta exitosamente.\n");
                break;

                case "b":
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
                        } else{
                            Console.WriteLine("\nSe cambió el estado del pedido.\n");
                        }
                    }
                }while(!int.TryParse(nro, out nroPedidoACambiar));
                break;

                case "c":
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
        }while(operacion != "d");

        Informe informe = oca.CrearInforme();
        MostrarInforme(informe);
    }

    private static void MostrarCantidadDePedidosDeCadetes(Cadeteria c){
        Console.WriteLine("\n============ CANTIDAD DE PEDIDOS POR CADETE ==============\n");
        foreach(var cad in c.ListaCadetes){
            Console.WriteLine($"Id: {cad.Id}       Nombre: {cad.Nombre}      Cant. pedidos: {cad.CantPedidosPendientes()}");
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
