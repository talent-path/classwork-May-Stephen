package com.tp.rpg;

import static com.tp.rpg.Application.chooseArmor;
import static com.tp.rpg.Application.chooseWeapon;

public class PlayerCharacter extends Character {

    //use scanner here to get something from the user
    @Override
    public void makeChoice() {
        int health = 1000;
        System.out.println("Prepare your fighter!");
        int armorValue = chooseArmor();
        int weaponValue = chooseWeapon();
        System.out.println();
        System.out.println("Your character now has " + health + " health." + "\n" +
                "Your weapon gives you an attack of " + weaponValue + "." + "\n" +
                "Your armor gives you a defensive value of " + armorValue + ". \n");
    }

}
