namespace primeraPrueba_C_.TareaInventario;

// Clase concreta de Weapon
public class Sword : Weapon
{
    // Llama al constructor base (padre) con los parametros iniciales para cuando se cree la instancia
    public Sword(): base("Sword", 20){}

    // Implementamos apply de la interaz, para aumentar el daño base
    public override void Apply(Character character)
    {
        Console.WriteLine($"{character.Name} se ha equipado una espada (+20 ataque)");
        character.BaseDamage += this.Damage;
    }
}