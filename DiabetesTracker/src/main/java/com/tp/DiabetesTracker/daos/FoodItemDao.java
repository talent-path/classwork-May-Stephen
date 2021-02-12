package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.models.FoodItem;

import java.util.List;

public interface FoodItemDao {
    FoodItem addFoodItem(FoodItem toAdd);

    List<FoodItem> getAllItems();
}
