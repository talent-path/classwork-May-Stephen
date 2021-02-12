package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.daos.mappers.IntegerMapper;
import com.tp.DiabetesTracker.models.FoodItem;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;


@Component
@Profile({"production", "daoTesting"})
public class FoodItemPostgresDao implements FoodItemDao{

    @Autowired
    JdbcTemplate template;

    @Override
    public FoodItem addFoodItem(FoodItem toAdd) {
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
}
