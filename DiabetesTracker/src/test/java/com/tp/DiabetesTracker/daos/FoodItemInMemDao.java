package com.tp.DiabetesTracker.daos;


import com.tp.DiabetesTracker.models.FoodItem;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;


@Component
@Profile("serviceTest")
public class FoodItemInMemDao implements FoodItemDao {


    @Autowired
    JdbcTemplate template;


    List<FoodItem> allItems = new ArrayList<>();

    @Override
    public FoodItem addFoodItem(FoodItem toAdd) {

        int id = 0;


        for(FoodItem toCheck : allItems) {
            if (toCheck.getFoodId() > id) {
                id = toCheck.getFoodId();
            }
        }

        id++;

        FoodItem copy = new FoodItem(toAdd);

        allItems.add(copy);

        return copy;

    }

    @Override
    public List<FoodItem> getAllItems() {
        List<FoodItem> copyList = new ArrayList<>();

        for(FoodItem toCopy : allItems) {
            copyList.add(new FoodItem(toCopy));
        }

        return copyList;
    }




}
