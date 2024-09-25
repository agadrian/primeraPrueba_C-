namespace primeraPrueba_C_.TareaInventario;

// Clase abstracta Protection que extiende la interfaz IItem
public abstract class Protection : IItem
{
    public string Name { get; set; }
    public int Armor { get; set; }

        
    public Protection(string name, int armor){
        this.Name = name;
        this.Armor = armor;
    }

    public abstract void Apply(Character character);
    
}