package com.tp.rpg.weapons;

import java.util.Random;

public class Hammer implements Weapon{
    @Override
    public int generateDamage() {
        Random rand = new Random();
        int damage = 170;
        int possibleMiss = rand.nextInt(10);
//            if( possibleMiss < 7) {
//                damage = 0;
//            }
            return damage;
    }
}
