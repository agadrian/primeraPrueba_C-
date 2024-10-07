namespace primeraPrueba_C_.TareaInventario;

// Clase abstracta Weapon que extiende la interfaz IItem
public abstract class Weapon : IItem
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public const int DamageDefault = 10;

    // Constructor que difine el nombre y daño
    public Weapon(string name, int damage = DamageDefault)
    {
        this.Name = name;
        this.Damage = damage;
    }

    // Mejor usar el apply aqui para aplicar cada cosa, y no en cada calse concreta de Weapon
    public void Apply(Character character)
    {
        character.BaseDamage += Damage;
    }
    
    public override string ToString()
    {
        return $"Nombre arma: {Name} - Daño ataque: {Damage}";
    }
}