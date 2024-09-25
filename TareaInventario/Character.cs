namespace primeraPrueba_C_.TareaInventario;

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