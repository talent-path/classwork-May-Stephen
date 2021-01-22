package com.tp.rpg.weapons;

import com.tp.rpg.Console;

import java.util.Random;

public class MagicStaff implements Weapon{
    @Override
    public int generateDamage() {
        Random rand = new Random();
        int extraDmg = 0;
        int luck = rand.nextInt(5);
            if (luck > 3) {
                extraDmg = 25;
            }
        return 75 + extraDmg;
    }
}
