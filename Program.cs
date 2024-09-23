using Inventory;

// Añadir:
// - Borrar el inventario de alguien cuando muere

namespace Inventory{


    public interface IItem
        {
            void Apply(Character character);
        }


    public class Character
    {
        public string Name { get; set; }
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int BaseDamage { get; set; }
        public int BaseArmor { get; set; }

        private List<IItem> Inventory { get; set; }


        // Constructor
        public Character(string name, int maxHitPoints, int baseDamage, int baseArmor)
        {

            this.Name = name;
            this.MaxHitPoints = maxHitPoints;
            this.CurrentHitPoints = maxHitPoints; // Empezara con la vida completa
            this.BaseDamage = baseDamage;
            this.BaseArmor = baseArmor;
            this.Inventory = new List<IItem>();
        }

        // Mostrar estadisticas y objetos del inventario
        public void ShowStats()
        {
            Console.WriteLine($"Estadisticas jugad@r:\n - Nombre: {Name}\n - Salud: {CurrentHitPoints} ({MaxHitPoints}max)\n - Armadura: {BaseArmor}\n - Daño de ataque: {BaseDamage}\n - Inventario:");

            if (Inventory.Count == 0)
            {
                Console.WriteLine("Inventario vacío");
            }
            else
            {
                foreach(var item in Inventory)
                {
                    Console.WriteLine($"   * {item.GetType().Name}"); // Obtener el tipo de objeto sin tener porque tener un campo name, unicamente que implemente la interfaz IItem 
                }
            }
        }


        // Añadir al inventario un  item de tipo IItem. Tambien se hace uso del Apply a sí mismo.
        public void AddItem(IItem item)
        {
            Inventory.Add(item);
            item.Apply(this);
        }


        // Metodo para recibir daño
        public int ReceiveDamage(int damage)
        {
            int damageToTake = damage - BaseArmor; // Recibe menos daño si tiene armadura

            if (damageToTake < 0) damageToTake = 0; // En caso de que tenga mas armadura que el daño a recibir

            CurrentHitPoints -= damageToTake;
            //Console.WriteLine($"{Name} ha recibido {damageToTake} daño");

            if (CurrentHitPoints < 0){ // Comprobar si ha perido toda la vida
                CurrentHitPoints = 0;
                //Console.WriteLine($"{Name} ha sido eliminado");
            }

            return damageToTake;
        }


        // Metodo atacar a otro character
        public int Attack(Character enemy)
        {
            if (enemy.CurrentHitPoints <= 0){ //Comprobar si ya esta muerto
                Console.WriteLine($"-*- Error al atacar: {enemy.Name} ya fue eliminado -*-");
                return 0;
            }

            int totalDamage = enemy.ReceiveDamage(BaseDamage);
            Console.WriteLine($"{Name} ataco a {enemy.Name} con un daño de {totalDamage}. Vida actual de {enemy.Name}: {enemy.CurrentHitPoints}");

            if (enemy.CurrentHitPoints == 0){
                Console.WriteLine($"{enemy.Name} ha sido eliminado");
            }
            return totalDamage;
        }


        // Metodo para defenderse
        public int Defense()
        {
            Random random = new Random();
            int tempArmorBoost = random.Next(2,8); // Num aleatorio entre 2 y 8.
            BaseArmor += tempArmorBoost; // Le sumamos armadura simulando la defensa
            Console.WriteLine($"{Name} se ha defendido, la armadura aumento en {tempArmorBoost} puntos");
            return tempArmorBoost;
        }

        // Metodo para curarse
        public void Heal(int amount)
        {
            CurrentHitPoints += amount;

            if (CurrentHitPoints > MaxHitPoints){
                CurrentHitPoints = MaxHitPoints;
                Console.WriteLine($"{Name} se ha curado al máximo ({CurrentHitPoints})");
            }else{
                Console.WriteLine($"{Name} se ha curado {amount} puntos de salud. Vida actual: {CurrentHitPoints}");
            }
        }
    }

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


    // Clase concreta de Weapon
    public class Axe : Weapon
    {
        // Llama al constructor base (padre) con los parametros iniciales para cuando se cree la instancia
        public Axe() : base("Axe", 15){} 

        // Implementamos apply de la interaz, para aumentar el daño base
        public override void Apply(Character character)
        {
            Console.WriteLine($"{character.Name} se ha equipado un hacha");
            character.BaseDamage += this.Damage;
        }
    }


    // Clase concreta de Weapon
    public class Sword : Weapon
    {
        // Llama al constructor base (padre) con los parametros iniciales para cuando se cree la instancia
        public Sword(): base("Sword", 20){}

        // Implementamos apply de la interaz, para aumentar el daño base
        public override void Apply(Character character)
        {
            Console.WriteLine($"{character.Name} se ha equipado una espada");
            character.BaseDamage += this.Damage;
        }
    }


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

    public class Shield : Protection
    {
        // Llama al constructor base (padre) con los parametros iniciales para cuando se cree la instancia
        public Shield() : base("Shield", 15){}

        public override void Apply(Character character)
        {
            Console.WriteLine($"{character.Name} se ha equipado un escudo");
            character.BaseArmor += this.Armor;
        }
    }


    public class Helmet : Protection
    {

        // Llama al constructor base (padre) con los parametros iniciales para cuando se cree la instancia
        public Helmet() : base("Helmet", 10){}

        public override void Apply(Character character)
        {
            Console.WriteLine($"{character.Name} se ha equipado un casco");
            character.BaseArmor += this.Armor;
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
         // Crear personajes
        Character ch1 = new Character("Adri", 50, 10, 5);  // Personaje con 50 HP, 10 de daño y 5 de armadura
        Character ch2 = new Character("Pedro", 40, 34, 2); // Personaje con 100 HP, 34 de daño y 2 de armadura
        Character ch3 = new Character("Lucia", 80, 15, 10); // Personaje con 80 HP, 15 de daño y 10 de armadura

        ch1.ShowStats();

        // Equipar armas y armaduras a los personajes
        IItem axe = new Axe();
        ch1.AddItem(axe);  // Adri equipa un hacha
       

        IItem sword = new Sword();
        ch2.AddItem(sword);  // Pedro equipa una espada
        ch1.AddItem(sword);

        IItem shield = new Shield();
        ch3.AddItem(shield);  // Lucia equipa un escudo

        IItem helmet = new Helmet();
        ch3.AddItem(helmet);  // Lucia también equipa un casco

        // Ataques
        ch1.Attack(ch2);  // Adri ataca a Pedro
        ch2.Attack(ch3);  // Pedro ataca a Lucia
        ch3.Attack(ch1);  // Lucia ataca a Adri

        // Defensas
        ch1.Defense();  // Adri se defiende
        ch2.Defense();  // Pedro se defiende

        // Curaciones
        ch1.Heal(20);  // Adri se cura 20 puntos de vida
        ch3.Heal(15);  // Lucia se cura 15 puntos de vida
        ch3.Heal(200);

        ch3.ShowStats();

        ch1.ShowStats();

        // Nuevos ataques
        ch2.Attack(ch1);  // Pedro ataca a Adri
        ch3.Attack(ch2);  // Lucia ataca a Pedro
        ch3.Attack(ch2);
        ch3.Attack(ch2);

    
    }
}



