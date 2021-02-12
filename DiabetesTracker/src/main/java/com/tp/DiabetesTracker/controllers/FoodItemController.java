package com.tp.DiabetesTracker.controllers;


import com.tp.DiabetesTracker.exceptions.*;
import com.tp.DiabetesTracker.models.BloodSugarRecord;
import com.tp.DiabetesTracker.models.FoodItem;
import com.tp.DiabetesTracker.services.BloodSugarManagementService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api")
public class FoodItemController {

    @Autowired
    BloodSugarManagementService service;


    @PostMapping("/fooditem")
    public ResponseEntity addFood(@RequestBody FoodItem toAdd) {

        FoodItem enteredItem = null;
        try {
            enteredItem = service.addFoodItem(toAdd);
        } catch (InvalidProteinException | InvalidFiberException | InvalidMealIdException | InvalidCaloriesException | InvalidQuantityException | InvalidFoodNameException | InvalidDateException | InvalidFatException | InvalidCarbsException e) {
            e.printStackTrace();
        }

        return ResponseEntity.ok(enteredItem);
    }

    @GetMapping("/allfooditems")
    public List<FoodItem> getAllItems() {
        return service.getAllItems();
    }
}