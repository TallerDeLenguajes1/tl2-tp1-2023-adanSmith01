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

    private static List<string> LeerDatos(string ruta){
        List<string> lineasDatos = new List<string>();
        string linea = "";
        using(StreamReader s = new StreamReader(ruta)){
            while((linea = s.ReadLine()) != null){
                lineasDatos.Add(linea);
            }
        }
        return lineasDatos;
    }

    public static List<Cadete> ObtenerListaCadetes(string rutaDatosCadete){
        List<Cadete> listaCadetes = new List<Cadete>();
        string[] datosCadete;
        if(ExisteArchivoDatos(rutaDatosCadete)){
            List<string> lineasDatosCadetes = LeerDatos(rutaDatosCadete);
            
            foreach(var l in lineasDatosCadetes){
                datosCadete = l.Split(',');
                Cadete c = new Cadete(datosCadete[0], datosCadete[1], datosCadete[2], datosCadete[3]);
                listaCadetes.Add(c);
            }
        }

        return listaCadetes;
    }

    public static Cadeteria ObtenerInfoCadeteria(string rutaDatosCadeteria){
        Cadeteria cadeteriaSinInfo = new Cadeteria();
        if(ExisteArchivoDatos(rutaDatosCadeteria)){
            List<string> linea = LeerDatos(rutaDatosCadeteria);
            string[] datosCadeteria = linea[0].Split(',');
            Cadeteria cadeteriaConInfo = new Cadeteria(datosCadeteria[0], datosCadeteria[1]);
            return cadeteriaConInfo;
        } else{
            return cadeteriaSinInfo;
        }
    }
}