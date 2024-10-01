namespace primeraPrueba_C_.TareaInventario;

public class Character
    {
        
        public const int DefaultMaxHp = 10;
        public const int DefaultBaseDamage = 1;
        public const int DefaultBaseArmor = 0;
        
        
        public string Name { get; set; }
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int BaseDamage { get; set; }
        public int BaseArmor { get; set; }

        private List<IItem> Inventory { get; set; }


        // Constructor
        public Character(
            string name,
            int maxHitPoints = DefaultMaxHp,
            int baseDamage = DefaultBaseDamage,
            int baseArmor = DefaultBaseArmor
            ) {
            this.Name = name;
            this.MaxHitPoints = maxHitPoints;
            this.CurrentHitPoints = maxHitPoints; // Empezara con la vida completa
            this.BaseDamage = baseDamage;
            this.BaseArmor = baseArmor;
            this.Inventory = new List<IItem>();
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

            if (CurrentHitPoints < 0){ // Comprobar si ha perido toda la vida
                CurrentHitPoints = 0;
            }
            return damageToTake;
        }


        // Metodo atacar a otro character
        public int Attack(Character enemy)
        {
            if (enemy.CurrentHitPoints <= 0){ //Comprobar si ya esta muerto
                return 0;
            }

            int totalDamage = enemy.ReceiveDamage(BaseDamage);
            
            if (enemy.CurrentHitPoints == 0){
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
            return tempArmorBoost;
        }

        // Metodo para curarse
        public void Heal(int amount)
        {
            CurrentHitPoints += amount;

            if (CurrentHitPoints > MaxHitPoints){
                CurrentHitPoints = MaxHitPoints;
            }
        }

        public override string ToString()
        {
            string msg = $"Pj: {Name} ({CurrentHitPoints}hp)\n";
            msg += $" Ataque: {BaseDamage}\n";
            msg += $" Defensa: {BaseArmor}\n";
            msg += $" Inventario:";
            
            foreach (var item in Inventory)
            {
                msg += $" * {item}";
            }
            
            return msg;
        }
    }