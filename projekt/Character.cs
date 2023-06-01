using System;

public class Character
{
    public string Name { get; private set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Mana { get; set; }

    public Character(string name, int health, int attack, int defense, int mana)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
        Mana = mana;
    }

    public void PrintStats()
    {
        Console.WriteLine("Nazwa postaci: " + Name);
        Console.WriteLine("Zdrowie: " + Health);
        Console.WriteLine("Atak: " + Attack);
        Console.WriteLine("Obrona: " + Defense);
        Console.WriteLine("Mana: " + Mana);
    }
}
