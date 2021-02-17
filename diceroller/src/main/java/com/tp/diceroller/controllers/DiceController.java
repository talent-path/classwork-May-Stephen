package com.tp.diceroller.controllers;

import com.tp.diceroller.services.RNG;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class DiceController {

    //Create GET request and Handler
    @GetMapping("/helloworld") // helps decide what URL calls this
    public String helloWorld(){
        return "Hello World.";


    }

    @GetMapping("/sixsides")
    public int sixSide(){
        return RNG.rollDice(6);
    }

    @GetMapping("/twentysides")
    public int twentySides(){
        return RNG.rollDice(20);
    }


    @GetMapping("nsides")
    public int nSides(Integer num){
        return RNG.rollDice(num);
    }

    @GetMapping("/nsides/{num}")
    public int nSidesPathVariable(@PathVariable Integer num){
        return RNG.rollDice(num);
    }
}
