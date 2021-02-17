package com.tp.diceroller.services;

import java.util.Random;

public class RNG {
    static Random rng = new Random();

    public static int rollDice(int size){
        int roll = rng.nextInt(size) + 1;
        return roll;
    }

}
