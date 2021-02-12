package com.tp.DiabetesTracker.daos.mappers;
import com.tp.DiabetesTracker.models.FoodItem;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;


public class FoodItemMapper implements RowMapper<FoodItem> {

    @Override
    public FoodItem mapRow(ResultSet resultSet, int i) throws SQLException {
    FoodItem mappedRecord = new FoodItem();


        mappedRecord.setFoodId(resultSet.getInt("ItemId"));
        mappedRecord.setName(resultSet.getString("Name"));
        mappedRecord.setCarbs(resultSet.getInt("Carbs"));
        mappedRecord.setFat(resultSet.getInt("Fat"));
        mappedRecord.setCalories(resultSet.getInt("Calories"));
        mappedRecord.setProtein(resultSet.getInt("Protein"));
        mappedRecord.setFiber(resultSet.getInt("Fiber"));
        mappedRecord.setMealId(resultSet.getInt("MealId"));
        mappedRecord.setQuantity(resultSet.getDouble("Quantity"));

        return mappedRecord;

    }

}
