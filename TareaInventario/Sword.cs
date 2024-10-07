namespace primeraPrueba_C_.TareaInventario;

// Clase concreta de Weapon
public class Sword : Weapon
{
    public new const int DamageDefault = 20;
    // Llama al constructor base (padre) con los parametros iniciales para cuando se cree la instancia
    public Sword(): base("Sword", DamageDefault){}

    /* Mejor hcaerlo directamente en la clase abstracta weapon
    // Implementamos apply de la interaz, para aumentar el daño base
    public override void Apply(Character character)
    {
        character.BaseDamage += this.Damage;
    }
    */
}