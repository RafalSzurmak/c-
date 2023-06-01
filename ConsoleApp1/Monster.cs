using System;

public class Monster
{
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public Monster(int health, int attack, int defense)
    {
        Health = health;
        Attack = attack;
        Defense = defense;
    }

    public void PrintStats()
    {
        Console.WriteLine("Zdrowie potwora: " + Health);
        Console.WriteLine("Atak potwora: " + Attack);
        Console.WriteLine("Obrona potwora: " + Defense);
    }
}
