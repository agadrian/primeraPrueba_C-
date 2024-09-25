namespace primeraPrueba_C_.TareaInventario;

// Clase concreta de Weapon
public class Axe : Weapon
{
    // Llama al constructor base (padre) con los parametros iniciales para cuando se cree la instancia
    public Axe() : base("Axe", 15){} 

    // Implementamos apply de la interaz, para aumentar el daño base
    public override void Apply(Character character)
    {
        Console.WriteLine($"{character.Name} se ha equipado un hacha (+15 ataque)");
        character.BaseDamage += this.Damage;
    }
}