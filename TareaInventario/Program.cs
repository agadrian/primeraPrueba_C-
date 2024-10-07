namespace primeraPrueba_C_.TareaInventario;


class Program
{
    static void Main(string[] args)
    {
        // Crear personajes
        Character player1 = new Character("Aragorn");
        Character player2 = new Character("Legolas");

        // Mostrar estadísticas iniciales
        Console.WriteLine("\n*** Estadísticas iniciales ***");
        Console.WriteLine(player1);
        Console.WriteLine(player2);

        
        var ringMinionDragon = new RingMinionGenerator("Dragon", 15);
        player1.AddItem(ringMinionDragon);
        Minion createdMinionDragon = ringMinionDragon.CreatedMinion;
        
        
        

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
        player2.AddItem(shield);  // Legolas se equipa un escudo

        // Mostrar estadísticas tras equipamiento
        Console.WriteLine("\n*** Estadísticas después de equipar ***");
        Console.WriteLine(player1);
        Console.WriteLine(player2);

        // Simular combates
        Console.WriteLine("\n*** Comienza el combate ***");
        
        // Legolas ataca primero
        Console.WriteLine("\nTurno de Legolas");
        player2.Attack(player1);

        // Aragorn se defiende
        Console.WriteLine("\nTurno de Aragorn - Se defiende");
        player1.Defense();
        
        
        
        
        // Elimino el minion creado al J1 y lo vuelvo a crear para ver que funcione
        Console.WriteLine($"\nEliminar minion {createdMinionDragon.Name}");
        player1.RemoveMinion(createdMinionDragon);
        Console.WriteLine($"Num de minions de {player1.Name}:  {player1.GetMinions().Count}");
        
        Console.WriteLine($"\nAñadir minion {createdMinionDragon.Name}");
        ringMinionDragon.Apply(player1);
        Console.WriteLine($"Num de minions de {player1.Name}:  {player1.GetMinions().Count}");
        
        
        
        
        
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
        Console.WriteLine(player1);
        Console.WriteLine(player2);
        
        Console.WriteLine($"\nEliminar minion {createdMinionDragon.Name}");
        player1.RemoveMinion(createdMinionDragon);
        
        // Ataques adicionales 
        Console.WriteLine("\nTurno de Aragorn - Ataque final");
        player1.Attack(player2);

        Console.WriteLine("\nTurno de Legolas - Ataque final");
        player2.Attack(player1);

        // Estadísticas finales tras el combate
        Console.WriteLine("\n*** Estadísticas finales tras el combate ***");
        Console.WriteLine(player1);
        Console.WriteLine(player2);
    }
    
}
    