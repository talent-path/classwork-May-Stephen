package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.exceptions.*;
import com.tp.DiabetesTracker.models.FoodItem;

import java.util.List;

public interface FoodItemDao {
    FoodItem addFoodItem(FoodItem toAdd) throws InvalidFatException, InvalidMealIdException, InvalidFoodNameException, InvalidFiberException, InvalidProteinException, InvalidQuantityException, InvalidCarbsException, InvalidDateException, InvalidCaloriesException;

    List<FoodItem> getAllItems();
}
