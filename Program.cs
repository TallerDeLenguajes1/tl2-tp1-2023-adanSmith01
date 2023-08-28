using EmpresaDeCadeteria;

internal class Program
{
    private static void Main(string[] args)
    {
        string rutaArchivoDatosCadeteria = "datosCadeteria.csv";
        string rutaArchivoDatosCadetes = "datosCadetes.csv";

        Cadeteria c = AccesoDatosCadeteria.ObtenerInfoCadeteria(rutaArchivoDatosCadeteria); //Verificado
        c.ListaCadetes = AccesoDatosCadeteria.ObtenerListaCadetes(rutaArchivoDatosCadetes); //Verificado

        //SISTEMA DE GESTIÓN
        Pedido ped = c.DarAltaPedido();
        c.AgregarPedido(ped);
        c.MostrarPedidos();
    }
}