using System;
using RPG.Abstracts;
using RPG.Interface;
using RPG.Weapons;
using RPG.ArmorType;
using RPG.Classes;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to an RPG Adventure!");
            Console.WriteLine("Choose your fighter (1 for Brute, 2 for Ninja, 3 for Troll) : ");
            string userInput = Console.ReadLine();
            Fighter fighter = new Brute();
            Weapon weapon = new Sword();
            Clothing armor = new Shirt();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("You chose a Brute.");
                    fighter = new Brute();
                    break;
                case "2":
                    Console.WriteLine("You chose a Ninja.");
                    fighter = new Ninja();
                    break;
                case "3":
                    Console.WriteLine("You chose a Troll.");
                    fighter = new Troll();
                    break;

            }

            Console.WriteLine("Choose a weapon! (1 for sword, 2 for fists, 3 for crossbow)");
            string userWeapon = Console.ReadLine();

            switch (userWeapon)
            {
                case "1":
                    Console.WriteLine("You chose a Sword.");
                    weapon = new Sword();
                    break;
                case "2":
                    Console.WriteLine("You chose your bare hands.");
                    weapon = new Fists();
                    break;
                case "3":
                    Console.WriteLine("You chose a crossbow.");
                    weapon = new Crossbow();
                    break;

            }

            Console.WriteLine("Choose a piece of armor. (1 for Helmet, 2 for Shield, or 3 for a shirt.)");
            string userArmor = Console.ReadLine();

            switch (userArmor)
            {
                case "1":
                    Console.WriteLine("You chose a helmet.");
                    armor = new Helmet();
                    break;
                case "2":
                    Console.WriteLine("You chose a shield.");
                    armor = new Shield();
                    break;
                case "3":
                    Console.WriteLine("You chose a shirt.");
                    armor = new Shirt();
                    break;

            }
            fighter.weapon = weapon;
            fighter.armor = armor;
            int roundNum = 1;
            int points = -1;
            Monster monster = new Monster();
            monster.TotalHealth = 0;
            while (fighter.TotalHealth>0)
            {
                if (monster.TotalHealth<=0)
                {
                    monster = new Monster();
                    points++;
                    if (points>0)
                    {
                        Console.WriteLine("You defeated the monster");
                        Console.WriteLine("Your total score is " + points);
                    }
                }
                fighter.Attack(monster);
                monster.Attack(fighter);
                Console.WriteLine("Round " + roundNum + " is over");
                Console.WriteLine("Your figher has " + fighter.TotalHealth);
                Console.WriteLine("Monster has " + monster.TotalHealth);
                roundNum++;
                
            }
            Console.WriteLine("Hero defeated");
            Console.WriteLine("Your score is " + points);
            Console.WriteLine("You made it to round " + roundNum);
        }
    }
}
