namespace primeraPrueba_C_.TareaInventario;

public class Helmet : Protection
{

    // Llama al constructor base (padre) con los parametros iniciales para cuando se cree la instancia
    public Helmet() : base("Helmet", 10){}

    public override void Apply(Character character)
    {
        Console.WriteLine($"{character.Name} se ha equipado un casco (+10 armadura)");
        character.BaseArmor += this.Armor;
    }
}