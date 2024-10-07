namespace primeraPrueba_C_.TareaInventario;

public class Shield : Protection
{
    public new const int ArmorDefault = 10;
    // Llama al constructor base (padre) con los parametros iniciales para cuando se cree la instancia
    public Shield() : base("Shield", ArmorDefault){}

    
}