namespace primeraPrueba_C_.TareaInventario;

public class Minion
{
    public string Name { get; set; }
    public int AttackDamage { get; set; }
    

    public Minion(string name, int attackDamage)
    {
        this.Name = name;
        this.AttackDamage = attackDamage;
    }
    

    public override string ToString()
    {
        return $"Minion {Name}, Ataque: {AttackDamage}";
    }
    
    
    
    
    
    
    
}
