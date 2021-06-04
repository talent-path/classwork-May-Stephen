using System;
using RPG.Abstracts;
using RPG.Interface;
using RPG.Weapons;
using RPG.ArmorType;
using RPG.Classes;
using System.Collections.Generic;

namespace RPG
{
    class Program
    {

        /*
        Players will have to try to fight their way from the upper left corner (0,0) to the lower right corner (14,14).
        Every time they spawn in the upper left, the room with populate with N randomly generated enemies (using the same constraints as below)
        at random locations, where N is equal to 1 + the number of rooms they have completed so far.

        At each step, the board will be drawn (with a border around the grid, a symbol for the player, a symbol for the exit,
        and symbols for each enemy).  At each step, the player may attempt to walk up, down, left, or right (bonus gold star if you can get this to work with just the arrow keys).
        Attempting to walk into a square where there is already an enemy will cause the player to instead attack.

 

        After the player has either moved or attacked (assuming they haven't made it to the goal),
        every enemy will each move one square towards the player.  If they are directly next to a player, they will attack the player instead.
        If they are blocked by one of their allies and cannot make an attack or move towards an attacking position, they will instead attack the enemy in their way!

 

        When any enemy dies, they should be removed from the board.  When the player reaches the escape square at the opposite,
        they will load into the next room which will have one more enemy.  This process repeats until the player dies or they defeat
        the last room in which all 223 available squares (every square other than the player and the exit) will be filled enemies!

 

        Players should be able to choose 1 of (at least) 3 character classes,
        each with different abilities (healing each turn, doing extra damage, % chance to dodge, etc).

        Players should be able to choose 1 of (at least) 3 weapons, each with different (random) damage formulas.

        Players should be able to choose 1 of (at least) 3 armors, each with different damage reduction formulas.

        Players should be given 1 health potion which they will automatically drink if their health would otherwise
        be reduced below zero (they should be alerted to this when it happens).
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to an RPG Adventure!");

            // Create player character
            Fighter fighter = ChooseFighter();
            Weapon weapon = ChooseWeapon();
            Clothing armor = ChooseArmor();


            fighter.weapon = weapon;
            fighter.armor = armor;

            fighter.row = 0;
            fighter.col = 0;

            char[,] printBoard = new char[15, 15];
            List<Fighter> enemies = new List<Fighter>();
            
            char player = 'X';
            
            int roomNum = 0;
            int numEnemies = roomNum + 1;

            char empty = '_';



            //Generate random enemy locations
            char[,] board = CreateArray(printBoard, player, empty);
            GenerateEnemies(board, numEnemies, enemies);
            PrintBoard(board, roomNum, fighter, enemies);

   
            // Begin game loop
            PlayerMove(board, player, empty, roomNum, enemies, fighter);


          

            //Monster monster = new Monster();
            //monster.TotalHealth = 0;
            //while (fighter.TotalHealth>0)
            //{
            //    if (monster.TotalHealth<=0)
            //    {
            //        monster = new Monster();
            //        points++;
            //        if (points>0)
            //        {
            //            Console.WriteLine("You defeated the monster");
            //            Console.WriteLine("Your total score is " + points);
            //        }
            //    }
            //    fighter.Attack(monster);
            //    monster.Attack(fighter);
            //    
            //    roundNum++;

            //}
            //Console.WriteLine("Hero defeated");
            //Console.WriteLine("Your score is " + points);
            //Console.WriteLine("You made it to round " + roundNum);
        }

        private static char[,] CreateArray(char[,] board, char player, char empty)
        {
            for (int row = 0; row < 15; row++)
            {
                for (int col = 0; col < 15; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        board[row, col] = player;
                    }
                    else if (row == 14 && col == 14)
                    {
                        board[row, col] = '@';
                    }
                    else
                    {
                        board[row, col] = empty;
                    }

                }

            }
            return board;
        }

        private static void GenerateEnemies(char[,] board, int numEnemies, List<Fighter> enemies)
        {
            Random rand = new Random();
            char enemyChar = 'O';
            int enemiesPlaced = 0;
            while (enemiesPlaced != numEnemies)
            {
                Fighter enemy = new Monster();
                
                int enemyRow = rand.Next(0, 14);
                int enemyCol = rand.Next(0, 14);
                if (enemyRow == 0 && enemyCol == 0)
                {
                    enemyRow = rand.Next(0, 14);
                    enemyCol = rand.Next(0, 14);
                }
                enemy.row = enemyRow;
                enemy.col = enemyCol;

                enemies.Add(enemy);

                board[enemyRow, enemyCol] = enemyChar;
                enemiesPlaced++;
                
            }

            
        }


        // Choose armor
        private static Clothing ChooseArmor()
        {
            Clothing armor = new Shirt();
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
            return armor;
        }


        // Choose weapon
        private static Weapon ChooseWeapon()
        {
            Console.WriteLine("Choose a weapon! (1 for sword, 2 for fists, 3 for crossbow)");
            string userWeapon = Console.ReadLine();
            Weapon weapon = new Sword();
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
            return weapon;
        }


        // Choose fighter
        private static Fighter ChooseFighter()
        {
            Console.WriteLine("Choose your fighter (1 for Brute, 2 for Ninja, 3 for Troll) : ");
            string userInput = Console.ReadLine();
            Fighter fighter = new Brute();



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
            return fighter;
        }




        // Print board in console

        private static void PrintBoard(char[,] board, int roomNum, Fighter fighter, List<Fighter> enemies)
        {
            Console.Clear();
            Console.WriteLine("You have made it to room " + roomNum);
            Console.WriteLine("Row: " + fighter.row + ", Col: " + fighter.col);
            Console.WriteLine($"You have {fighter.TotalHealth} health remaining.");
            if (enemies.Count == 1)
            {
                Console.WriteLine($"There is 1 enemy in this room.");
            }
            else
            {
                Console.WriteLine($"There are {enemies.Count} enemies in this room!");
            }
            
            
            foreach(IFighter enemy in enemies)
            {
                Console.WriteLine($"Enemy at row: {enemy.row} and col: {enemy.col}");
            }

            for (int row = 0; row < board.GetLength(0); row++)
            {

                for (int col = 0; col < board.GetLength(1); col++)
                {

                    Console.Write(" {0} |", board[row, col]);
                }
                Console.Write(Environment.NewLine + Environment.NewLine);

            }


        }

        // Allow player to move around on board

        private static void PlayerMove(char[,] board, char player, char empty, int roomNum, List<Fighter> enemies, Fighter fighter)
        {
            if (board[14, 14] == player)
            {
                Console.Clear();
                Console.WriteLine("Congrats! You made it through the room!");
                roomNum++;
                enemies.Clear();
                if (roomNum < 223)
                {
                    char[,] newRoom = CreateArray(board, player, empty);
                    GenerateEnemies(newRoom, roomNum + 1, enemies);
                    PrintBoard(newRoom, roomNum, fighter, enemies);
                    fighter.row = 0;
                    fighter.col = 0;
                    PlayerMove(board, player, empty, roomNum, enemies, fighter);

                }
            }
            else if (fighter.TotalHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine($"You were defeated! You made it to room {roomNum}.");
            }
            else
                {
                Console.WriteLine("Use the arrow keys to move in any direction.");

                var cki = Console.ReadKey().Key;


                for (int row = 0; row < 15; row++)
                {
                    for (int col = 0; col < 15; col++)
                    {


                        if (board[row, col] == player)
                        {
                            switch (cki)
                            {
                                case ConsoleKey.RightArrow:
                                    {
                                        if (col == 14)
                                        {
                                            Console.WriteLine("Invalid choice, can't go right. Choose again.");
                                            PlayerMove(board, player, empty, roomNum, enemies, fighter);
                                        }
                                        else if (EnemyPresent(fighter.row, fighter.col, enemies))
                                        {

                                            foreach (Fighter enemy in enemies)
                                            {
                                                 if (enemy.col == fighter.col + 1 && enemy.row == fighter.row)
                                                {
                                                    Battle(fighter, enemy, board, enemies);
                                                }
                                            }
                                           

                                        }
                                        else
                                        {
                                            Console.WriteLine("You moved right.");
                                            board[row, col + 1] = player;
                                            board[row, col] = empty;
                                            fighter.col += 1;
                                            PrintBoard(board, roomNum, fighter, enemies);
                                            EnemyMove(board, player, empty, roomNum, enemies, fighter, enemies.Count);
                                        }

                                        break;
                                    }
                                case ConsoleKey.LeftArrow:
                                    {
                                        if (col == 0)
                                        {
                                            Console.WriteLine("Invalid choice, can't go left. Choose again.");
                                            PlayerMove(board, player, empty, roomNum, enemies, fighter);
                                        }
                                        else if (EnemyPresent(fighter.row, fighter.col - 1, enemies))
                                        {
                                            foreach (Fighter enemy in enemies)
                                            {
                                                if (enemy.col == fighter.col - 1 && enemy.row == fighter.row)
                                                {
                                                    Battle(fighter, enemy, board, enemies);
                                                }
                                            }

                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You moved left.");
                                            board[row, col - 1] = player;
                                            board[row, col] = empty;
                                            fighter.col -= 1;
                                            PrintBoard(board, roomNum, fighter, enemies);
                                            EnemyMove(board, player, empty, roomNum, enemies, fighter, enemies.Count);
                                        }

                                        break;
                                    }
                                case ConsoleKey.DownArrow:
                                    {
                                        if (row == 14)
                                        {
                                            Console.WriteLine("Invalid choice, can't go down. Choose again.");
                                            PlayerMove(board, player, empty, roomNum, enemies, fighter);
                                        }
                                        else if (EnemyPresent(fighter.row + 1, fighter.col, enemies))
                                        {
                                            foreach (Fighter enemy in enemies)
                                            {
                                                if (enemy.col == fighter.col && enemy.row == fighter.row + 1)
                                                {
                                                    Battle(fighter, enemy, board, enemies);
                                                }
                                            }

                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You moved down.");
                                            board[row + 1, col] = player;
                                            board[row, col] = empty;
                                            fighter.row += 1;
                                            PrintBoard(board, roomNum, fighter, enemies);
                                            EnemyMove(board, player, empty, roomNum, enemies, fighter, enemies.Count);

                                        }
                                        break;
                                    }
                                case ConsoleKey.UpArrow:
                                    {
                                        if (row == 0)
                                        {
                                            Console.WriteLine("Invalid choice, can't go up. Choose again.");
                                            PlayerMove(board, player, empty, roomNum, enemies, fighter);
                                        }
                                        else if (EnemyPresent(fighter.row - 1, fighter.col, enemies))
                                        {
                                            foreach (Fighter enemy in enemies)
                                            {
                                                if (enemy.col == fighter.col && enemy.row == fighter.row - 1)
                                                {
                                                    Battle(fighter, enemy, board, enemies);
                                                }
                                            }

                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You moved up.");
                                            board[row - 1, col] = player;
                                            board[row, col] = empty;
                                            fighter.row -= 1;
                                            PrintBoard(board, roomNum, fighter, enemies);
                                            EnemyMove(board, player, empty, roomNum, enemies, fighter, enemies.Count);
                                        }

                                        break;
                                    }


                            }

                        }



                    }



                }
            }

        }

        private static void EnemyMove(char[,] board, char player, char empty, int roomNum, List<Fighter> enemies, Fighter fighter, int numEnemies)
        {
            if (numEnemies > 0)
            {

                foreach (Fighter enemy in enemies)
                {
                    int verticalDistance = fighter.row - enemy.row;
                    int horizontalDistance = fighter.col - enemy.col;

                    if ((Math.Abs(horizontalDistance) == 1 && verticalDistance == 0) || (Math.Abs(verticalDistance) == 1 && horizontalDistance == 0))
                    {
                        Battle(enemy, fighter, board, enemies);
                    }

                    else if (Math.Abs(horizontalDistance) > Math.Abs(verticalDistance))
                    {
                        // player is to the right
                        if (horizontalDistance > 0)
                        {
                            board[enemy.row, enemy.col] = empty;
                            enemy.col += 1;
                            board[enemy.row, enemy.col] = 'O';
                        }
                        // player is to the left
                        else
                        {
                            board[enemy.row, enemy.col] = empty;
                            enemy.col -= 1;
                            board[enemy.row, enemy.col] = 'O';
                        }
                    }
                    else
                    {
                        // player is below
                        if (verticalDistance > 0)
                        {
                            board[enemy.row, enemy.col] = empty;
                            enemy.row += 1;
                            board[enemy.row, enemy.col] = 'O';
                        }
                        //player is above
                        else
                        {
                            board[enemy.row, enemy.col] = empty;
                            enemy.row -= 1;
                            board[enemy.row, enemy.col] = 'O';
                        }
                    }
                }
                PlayerMove(board, player, empty, roomNum, enemies, fighter);
            }
            else
            {
                PlayerMove(board, player, empty, roomNum, enemies, fighter);
            }
            
        }

        private static void Battle(Fighter fighter, Fighter enemy, char[,] board, List<Fighter> enemies)
        {
            fighter.Attack(enemy);
            if (enemy.TotalHealth <= 0)
            {
                enemies.Remove(enemy);
                board[fighter.row, fighter.col] = '_';
                fighter.col = enemy.col;
                fighter.row = enemy.row;
                board[fighter.row, fighter.col] = 'X';
            }

        }

        private static bool EnemyPresent(int newFighterRow, int newFighterCol, List<Fighter> enemies)
        {
            foreach(Fighter enemy in enemies)
            {
                if (enemy.col == newFighterCol && enemy.row == newFighterRow)
                {
                    return true;
                }
            }

            return false;
        }

        
    }
}
