namespace primeraPrueba_C_.TareaInventario;

// Clase abstracta Protection que extiende la interfaz IItem
public abstract class Protection : IItem
{
    
    public string Name { get; set; }
    public int Armor { get; set; }

    public const int ArmorDefault = 5;
        
    public Protection(string name, int armor = ArmorDefault){
        this.Name = name;
        this.Armor = armor;
    }

    public virtual void Apply(Character character)
    {
        character.BaseArmor += this.Armor;
    }

    public override string ToString()
    {
        return $"Nombre proteccion: {Name} - Proteccion: {Armor}";
    }
}