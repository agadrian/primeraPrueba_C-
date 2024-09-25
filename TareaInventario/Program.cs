namespace primeraPrueba_C_.TareaInventario;


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