namespace primeraPrueba_C_.TareaInventario;

// Clase abstracta Weapon que extiende la interfaz IItem
public abstract class Weapon : IItem
{
    public string Name { get; set; }
    public int Damage { get; set; }

    // Constructor que difine el nombre y daño
    public Weapon(string name, int damage)
    {
        this.Name = name;
        this.Damage = damage;
    }

    public abstract void Apply(Character character);
}