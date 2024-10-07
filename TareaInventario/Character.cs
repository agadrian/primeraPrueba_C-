namespace primeraPrueba_C_.TareaInventario;

public class Character
    {
        public const int DefaultMaxHp = 25;
        public const int DefaultBaseDamage = 1;
        public const int DefaultBaseArmor = 0;        
        
        public string Name { get; set; }
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int BaseDamage { get; set; }
        public int BaseArmor { get; set; }

        private List<IItem> _Inventory { get; set; }
        private List<Minion> _Minions { get; set; }
        


        // Constructor
        public Character(
            string name,
            int maxHitPoints = DefaultMaxHp,
            int baseDamage = DefaultBaseDamage,
            int baseArmor = DefaultBaseArmor
            )
        {
            this.Name = name;
            this.MaxHitPoints = maxHitPoints;
            this.CurrentHitPoints = maxHitPoints; // Empezara con la vida completa
            this.BaseDamage = baseDamage;
            this.BaseArmor = baseArmor;
            this._Inventory = new List<IItem>();
            this._Minions = new List<Minion>();
        }
        
        // Metodo para añadir minion al listado
        public void AddMinion(Minion minion)
        {
            this._Minions.Add(minion);
            BaseDamage += minion.AttackDamage;
        }
        
        // Metodo para quitar el minion de la lista
        public void RemoveMinion(Minion minion)
        {
            if (_Minions.Contains(minion))
            {
                this._Minions.Remove(minion);
                this.
                BaseDamage -= minion.AttackDamage;
            }
        }

        public List<Minion> GetMinions()
        {
            return this._Minions;
        }
        
        

        // Añadir al inventario un  item de tipo IItem. Tambien se hace uso del Apply a sí mismo.
        public void AddItem(IItem item) // => Inventory.Add(item);
        {
            _Inventory.Add(item);
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
            
            int damageFinal = enemy.ReceiveDamage(BaseDamage);
            
            if (enemy.CurrentHitPoints == 0){
                enemy.DeleteInventory();
            }
            
            Console.WriteLine($"Ataque con {damageFinal}hp");
            return damageFinal;
        }

        private void DeleteInventory()
        {
            _Inventory.Clear();
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
            msg += $" Lista de minions: \n";
            foreach (var minion in _Minions)
            {
                msg += $" * {minion}\n";
            }
            
            msg += $" Inventario:\n";
            
            foreach (var item in _Inventory)
            {
                msg += $" * {item}\n";
            }
            
            return msg;
        }
    }