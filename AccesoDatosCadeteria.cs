namespace EmpresaDeCadeteria;

public static class  AccesoDatosCadeteria
{
    private static bool ExisteArchivoDatos(string ruta){
        FileInfo f = new FileInfo(ruta);

        if(f.Exists && f.Length > 0){
            return true;
        }else{
            return false;
        }
    }

    public static Cadeteria ObtenerInfoCadeteria(string rutaDatosCadeteria){
        Cadeteria cadeteriaSinInfo = new Cadeteria();

        if(ExisteArchivoDatos(rutaDatosCadeteria)){
            string[] datosCadeteria;

            using (StreamReader s = new StreamReader(rutaDatosCadeteria))
            {
                datosCadeteria = s.ReadLine().Split(',');
            }

            Cadeteria cadeteriaConInfo = new Cadeteria(datosCadeteria[0], datosCadeteria[1]);
            return cadeteriaConInfo;
        } else{
            return cadeteriaSinInfo;
        }
    } 

    public static List<Cadete> ObtenerListaCadetes(string rutaDatosCadetes){
        List<Cadete> cadetes = new List<Cadete>();

        if(ExisteArchivoDatos(rutaDatosCadetes)){
            string linea = "";
            string[] datosCadete;

            using(StreamReader s = new StreamReader(rutaDatosCadetes))
            {
                while((linea = s.ReadLine()) != null){
                    datosCadete = linea.Split(',');
                    Cadete cadete = new Cadete(datosCadete[0], datosCadete[1], datosCadete[2], datosCadete[3]);
                    cadetes.Add(cadete);
                }
            }

        }

        return cadetes;
    }
}