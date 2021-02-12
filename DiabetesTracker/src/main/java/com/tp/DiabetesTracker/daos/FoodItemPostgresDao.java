package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.daos.mappers.FoodItemMapper;
import com.tp.DiabetesTracker.daos.mappers.IntegerMapper;
import com.tp.DiabetesTracker.exceptions.*;
import com.tp.DiabetesTracker.models.FoodItem;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

import java.util.List;


@Component
@Profile({"production", "daoTesting"})
public class FoodItemPostgresDao implements FoodItemDao{

    @Autowired
    JdbcTemplate template;

    @Override
    public FoodItem addFoodItem(FoodItem toAdd) throws InvalidMealIdException, InvalidFoodNameException,
            InvalidFiberException, InvalidProteinException, InvalidFatException, InvalidQuantityException, InvalidCarbsException, InvalidDateException, InvalidCaloriesException {
        if (toAdd.getName() == null) throw new InvalidFoodNameException("Invalid name of food entered.");
        if(toAdd.getQuantity() == null) throw new InvalidQuantityException("Invalid quantity value entered.");
        if(toAdd.getCalories() == null) throw new InvalidCaloriesException("Invalid calories value entered.");
        if(toAdd.getCarbs() == null) throw new InvalidCarbsException("Invalid carbs value entered");
        if(toAdd.getFat() == null) throw new InvalidFatException("Invalid fat value entered.");
        if(toAdd.getProtein() == null) throw new InvalidProteinException("Invalid protein value entered.");
        if(toAdd.getFiber() == null) throw new InvalidFiberException("Invalid fiber value entered.");
        if(toAdd.getMealId() == null) throw new InvalidMealIdException("Invalid meal ID value entered");
        if(toAdd.getDate() == null) throw new InvalidDateException("Invalid date value entered.");

        Integer foodId = template.queryForObject("INSERT INTO public.\"FoodItems\"(\n" +
                        "\t\"Name\", \"Carbs\", \"Fat\", \"Calories\", \"Protein\", \"Fiber\", \"MealId\", \"Quantity\", \"Date\")\n" +
                        "\tVALUES (?, ?, ?, ?, ?, ?, ?, ?, CURRENT_DATE) RETURNING \"ItemId\";",
                new IntegerMapper("ItemId"),
                toAdd.getName(),
                toAdd.getCarbs(),
                toAdd.getQuantity(),
                toAdd.getCalories(),
                toAdd.getFat(),
                toAdd.getProtein(),
                toAdd.getFiber(),
                toAdd.getMealId());

        toAdd.setFoodId(foodId);

        return toAdd;
    }

    @Override
    public List<FoodItem> getAllItems() {
        List<FoodItem> allItems = template.query("SELECT * FROM \"FoodItems\"", new FoodItemMapper());

                return allItems;
    }


}
