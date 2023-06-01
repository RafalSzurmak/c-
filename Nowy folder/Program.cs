using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Nazwanie postaci
        Console.WriteLine("Podaj nazwę swojej postaci:");
        string playerName = Console.ReadLine();

        // Tworzenie postaci
        Character player = new Character(playerName, 100, 10, 5, 50);

        // Licznik pokonanych potworów
        int defeatedMonsters = 0;

        // Rozpoczęcie gry
        Console.WriteLine("Witaj, " + player.Name + "! Rozpoczynamy grę!");

        while (player.Health > 0)
        {
            // Losowanie potwora
            Monster[] monsters = new Monster[]
            {
                new Monster(50, 5, 2),   // Potwór 1
                new Monster(75, 8, 3),   // Potwór 2
                new Monster(90, 10, 4)   // Potwór 3
            };

            Random random = new Random();
            int monsterIndex = random.Next(0, monsters.Length);
            Monster currentMonster = monsters[monsterIndex];

            // Rozpoczęcie walki z potworem
            Console.WriteLine();
            Console.WriteLine("Pokonaj potwora nr " + (defeatedMonsters + 1) + "!");
            player.PrintStats();
            currentMonster.PrintStats();

            while (player.Health > 0 && currentMonster.Health > 0)
            {
                // Wybór ataku
                Console.WriteLine();
                Console.WriteLine("Wybierz atak: ");
                Console.WriteLine("1. Słaby atak");
                Console.WriteLine("2. Silny atak");

                int attackChoice = Convert.ToInt32(Console.ReadLine());

                int damageToMonster = 0;

                // Atak postaci na potwora
                if (attackChoice == 1)
                {
                    damageToMonster = player.Attack - currentMonster.Defense;
                    player.Mana += 10;
                }
                else if (attackChoice == 2)
                {
                    if (player.Mana >= 20)
                    {
                        damageToMonster = player.Attack * 2 - currentMonster.Defense;
                        player.Mana -= 20;
                    }
                    else
                    {
                        Console.WriteLine("Nie masz wystarczającej many do wykonania silnego ataku!");
                        continue;
                    }
                }

                damageToMonster = Math.Max(damageToMonster, 0);  // Zapobiega zadawaniu ujemnego obrażeń
                currentMonster.Health -= damageToMonster;

                Console.WriteLine("Atakujesz potwora i zadajesz " + damageToMonster + " obrażeń.");

                // Sprawdzanie, czy potwór został pokonany
                if (currentMonster.Health <= 0)
                {
                    Console.WriteLine("Pokonałeś potwora nr " + (defeatedMonsters + 1) + "!");
                    defeatedMonsters++;
                    player.Mana += 20;
                    break;
                }

                // Atak potwora na postać
                int damageToPlayer = currentMonster.Attack - player.Defense;
                damageToPlayer = Math.Max(damageToPlayer, 0);  // Zapobiega zadawaniu ujemnego obrażeń
                player.Health -= damageToPlayer;

                Console.WriteLine("Potwór atakuje i zadaje ci " + damageToPlayer + " obrażeń.");

                // Sprawdzanie, czy postać została pokonana
                if (player.Health <= 0)
                {
                    Console.WriteLine("Zostałeś pokonany przez potwora...");
                    break;
                }

                // Wyświetlanie aktualnych statystyk
                player.PrintStats();
                currentMonster.PrintStats();
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("Gra się skończyła. Zginąłeś w walce...");
                break;
            }
        }

        Console.WriteLine("Pokonałeś " + defeatedMonsters + " potworów! Koniec gry.");
        Console.ReadLine();
    }
}
;