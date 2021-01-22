package com.tp.rpg;

import com.tp.rpg.armors.Boots;
import com.tp.rpg.armors.ChestPiece;
import com.tp.rpg.armors.Helmet;
import com.tp.rpg.armors.Shield;
import com.tp.rpg.weapons.Fist;
import com.tp.rpg.weapons.Hammer;
import com.tp.rpg.weapons.MagicStaff;
import com.tp.rpg.weapons.Sword;

import java.util.Random;

public class Application {
    public static void main(String[] args) {

        PlayerCharacter pc = setUpPlayer();

        while( pc.isAlive() ){
            NonPlayerCharacter enemy = setUpEnemy();

            battle( pc, enemy );


        }

        gameOverScreen();

    }

    //walk the user through setting up their character
    private static PlayerCharacter setUpPlayer() {
        PlayerCharacter player = new PlayerCharacter();

        player.makeChoice();
        return player;
    }

    //create some NPC object (with armor & weapons?)
    private static NonPlayerCharacter setUpEnemy() {
        int health = 1000;
        Random rand = new Random();
        System.out.println("Your enemy is ready to fight!");
        System.out.println("They have " + health + " health.");
        int armor = rand.nextInt(4);
        int enemyArmor = enemyArmor(armor);
        System.out.println("There defensive value is " + enemyArmor);
        int weapon = rand.nextInt(4);
        int enemyWeapon = enemyWeapon(weapon);
        System.out.println("There attack value is " + enemyWeapon);
        return null;
    }


    //a and b battle until one is dead
    private static void battle(Character a, Character b) {
        Character attacker = a;
        Character defender = b;

//        while( a.isAlive() && b.isAlive() ){
//            if( a.makeChoice() == 1) {
//                attacker.attack(defender);
//            } else if(a.makeChoice()== 2) {
//               chooseWeapon();
//            }
//            else if(a.makeChoice()== 3) {
//                chooseArmor();
//            }

            Character temp = a;
            a = b;
            b = temp;

            //TODO: display HP status?
            throw new UnsupportedOperationException();
        }


    //display some message
    private static void gameOverScreen() {
    throw new UnsupportedOperationException();
    }

    public static int chooseWeapon() {
        System.out.println("Choose your weapon.");
        int weaponDamage = 0;
        int weaponChoice =
                Console.readInt("1 - Sword, 2 - Magic Staff, 3 - Fists, 4 - Hammer : ", 1, 4);
        switch (weaponChoice) {
            case 1:
                Sword sword = new Sword();
                weaponDamage = sword.generateDamage();
                System.out.println("Can't go wrong with a sword!");
                break;
            case 2:
                MagicStaff staff = new MagicStaff();
                weaponDamage = staff.generateDamage();
                System.out.println("The Magic Staff has a chance to deal extra damage!");
                break;
            case 3:
                Fist fists = new Fist();
                weaponDamage = fists.generateDamage();
                System.out.println("Not sure why you chose fists....");
                break;
            case 4:
                Hammer hammer = new Hammer();
                weaponDamage = hammer.generateDamage();
                System.out.println("The hammer can deal massive damage, but its slow so you might miss!");
        }
        return weaponDamage;
    }

    public static int chooseArmor() {
        System.out.println("Choose your armor.");
        int armorValue = 0;
        int armorChoice =
                Console.readInt("1 - Shield, 2 - Helmet, 3 - Chest Plate, 4 - Boots): ", 1, 4);
        switch (armorChoice) {
            case 1:
                Shield shield = new Shield();
                armorValue = shield.reduceDamage();
                break;
            case 2:
                Helmet helmet = new Helmet();
                armorValue = helmet.reduceDamage();
                break;
            case 3:
                ChestPiece chest = new ChestPiece();
                armorValue = chest.reduceDamage();
                break;
            case 4:
                Boots boots = new Boots();
                armorValue = boots.reduceDamage();
        }
        return armorValue;
    }

    public static int enemyArmor(int armor) {
        int armorValue = 0;
        switch(armor) {
            case 1:
                System.out.println("Enemy has a shield!");
                armorValue = 50;
                break;
            case 2:
                System.out.println("Enemy has a helmet!");
                armorValue = 30;
                break;
            case 3:
                System.out.println("Enemy has a chest plate!");
                armorValue = 40;
                break;
            case 4:
                System.out.println("Enemy has boots!");
                armorValue = 20;
        }
        return armorValue;
    }
    public static int enemyWeapon(int weapon) {
        int attackValue = 0;
        switch (weapon) {
            case 1:
                System.out.println("Enemy brought a sword to battle!");
                attackValue = 85;
            case 2:
                System.out.println("Enemy brought a Magic Staff to battle! Watch out for critical hits!");
                attackValue = 75;
            case 3:
                System.out.println("Enemy is prepared to fight you with his bare hands!");
                attackValue = 25;
            case 4:
                System.out.println("Enemy brought a hammer to battle! They may be slow, but they hit hard!");
                attackValue = 170;

        }
        return attackValue;
    }
}
