namespace primeraPrueba_C_.TareaInventario;

public class RingMinionGenerator: IItem
{
    private Minion _minion;
    

    public RingMinionGenerator(string minionName, int attackDamge)
    {
        _minion = new Minion(minionName, attackDamge);
    }
    
    // Creamos y añadimos el minion a la lista de minions cuandos e aplique el item minion 
    public void Apply(Character character)
    {
        character.AddMinion(_minion);
    }
    
    public Minion CreatedMinion => _minion;

    public override string ToString()
    {
        return $"Ring generator of minion. Minion: {_minion.Name}, Atack damage: {_minion.AttackDamage}";
    }
}