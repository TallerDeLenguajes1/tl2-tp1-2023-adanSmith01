namespace EmpresaDeCadeteria;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    
    public int Id{get => id;}
    public string Nombre{get => nombre;}
     
    public Cadete(int id, string nombre, string direccion, string telefono){
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }

    public Cadete(string id, string nombre, string direccion, string telefono){
        this.id = Convert.ToInt32(id);
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }

    // Métodos
    
}