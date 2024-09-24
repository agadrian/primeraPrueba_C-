using System.Data;
using Inventory;



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
                Console.WriteLine("   * Inventario vacío");
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
        public void AddItem(IItem item) // => Inventory.Add(item);
        {
            Inventory.Add(item);
            item.Apply(this);
        }


        // Metodo para recibir daño
        private int ReceiveDamage(int damage)
        {
            int damageToTake = damage - BaseArmor; // Recibe menos daño si tiene armadura

            if (damageToTake <= 0) damageToTake = 1; // En caso de que tenga mas armadura que el daño a recibir

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
                enemy.DeleteInventory();

            }
            return totalDamage;
        }

        private void DeleteInventory()
        {
            Inventory.Clear();
            BaseArmor = 0;
            BaseDamage = 0;
            MaxHitPoints = 0;
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

        public override string ToString()
        {
            string hola = $"{Name} ({CurrentHitPoints})";
            
            return hola;
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
            Console.WriteLine($"{character.Name} se ha equipado un hacha (+15 ataque)");
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
            Console.WriteLine($"{character.Name} se ha equipado una espada (+20 ataque)");
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
            Console.WriteLine($"{character.Name} se ha equipado un escudo (+15 armadura)");
            character.BaseArmor += this.Armor;
        }
    }


    public class Helmet : Protection
    {

        // Llama al constructor base (padre) con los parametros iniciales para cuando se cree la instancia
        public Helmet() : base("Helmet", 10){}

        public override void Apply(Character character)
        {
            Console.WriteLine($"{character.Name} se ha equipado un casco (+10 armadura)");
            character.BaseArmor += this.Armor;
        }
    }
    
   
}

class Program
{
    static void Main(string[] args)
    {
        // Crear personajes
        Character player1 = new Character("Aragorn", 100, 45, 5);
        Character player2 = new Character("Legolas", 90, 52, 3);

        // Mostrar estadísticas iniciales
        Console.WriteLine("\n*** Estadísticas iniciales ***");
        player1.ShowStats();
        player2.ShowStats();

        // Equipar armas
        Console.WriteLine("\n*** Equipar armas ***");
        Sword sword = new Sword();
        Axe axe = new Axe();

        player1.AddItem(sword); // Aragorn se equipa una espada
        player2.AddItem(axe);   // Legolas se equipa un hacha

        // Equipar protecciones
        Console.WriteLine("\n*** Equipar protecciones ***");
        Shield shield = new Shield();
        Helmet helmet = new Helmet();

        player1.AddItem(shield);  // Aragorn se equipa un escudo
        player2.AddItem(helmet);  // Legolas se equipa un casco

        // Mostrar estadísticas tras equipamiento
        Console.WriteLine("\n*** Estadísticas después de equipar ***");
        player1.ShowStats();
        player2.ShowStats();

        // Simular combates
        Console.WriteLine("\n*** Comienza el combate ***");
        
        // Legolas ataca primero
        Console.WriteLine("\nTurno de Legolas");
        player2.Attack(player1);

        // Aragorn se defiende
        Console.WriteLine("\nTurno de Aragorn - Se defiende");
        player1.Defense();

        // Aragorn contraataca
        Console.WriteLine("\nTurno de Aragorn - Ataca");
        player1.Attack(player2);

        // Legolas se cura
        Console.WriteLine("\nTurno de Legolas - Se cura 20 puntos");
        player2.Heal(20);

        // Legolas ataca de nuevo
        Console.WriteLine("\nTurno de Legolas - Ataca");
        player2.Attack(player1);

        // Mostrar estadísticas finales
        Console.WriteLine("\n*** Estadísticas después del combate ***");
        player1.ShowStats();
        player2.ShowStats();

        // Ataques adicionales 
        Console.WriteLine("\nTurno de Aragorn - Ataque final");
        player1.Attack(player2);

        Console.WriteLine("\nTurno de Legolas - Ataque final");
        player2.Attack(player1);

        // Estadísticas finales tras el combate
        Console.WriteLine("\n*** Estadísticas finales tras el combate ***");
        player1.ShowStats();
        player2.ShowStats();
    }
    
}
    





/* Distintas pruebas del main */

/* 
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


// Prueba 2

// Crear personajes
        Character ch1 = new Character("Adri", 50, 32, 5);  // Personaje con 50 HP, 10 de daño y 5 de armadura
        Character ch2 = new Character("Pedro", 115, 35, 0); // Personaje con 100 HP, 34 de daño y 2 de armadura
        Character ch3 = new Character("Lucia", 80, 15, 10); // Personaje con 80 HP, 15 de daño y 10 de armadura

        ch1.ShowStats();

        // Equipar armas y armaduras a los personajes
        IItem axe = new Axe();
        ch1.AddItem(axe);  // Adri equipa un hacha
        IItem sword = new Sword();
        //ch1.AddItem(sword); 


        ch1.ShowStats();
        ch2.ShowStats();

        IItem helmet = new Helmet();
        ch2.AddItem(helmet);  
        IItem shield = new Shield();
        ch2.AddItem(shield);

        ch2.ShowStats();

        ch1.Attack(ch2);
        ch2.ShowStats();
        ch1.Attack(ch2);
        ch2.ShowStats();
        ch1.Attack(ch2);
        ch2.ShowStats();
        ch1.Attack(ch2);
        ch2.ShowStats();
        ch1.Attack(ch2);
        ch2.ShowStats();
        ch1.Attack(ch2);
        ch2.ShowStats();

*/