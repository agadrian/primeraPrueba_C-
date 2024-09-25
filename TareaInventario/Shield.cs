namespace primeraPrueba_C_.TareaInventario;

public class Shield : Protection
{
    // Llama al constructor base (padre) con los parametros iniciales para cuando se cree la instancia
    public Shield() : base("Shield", 15){}

    public override void Apply(Character character)
    {
        Console.WriteLine($"{character.Name} se ha equipado un escudo (+15 armadura)");
        character.BaseArmor += this.Armor;
    }
}