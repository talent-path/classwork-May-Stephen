package com.tp.DiabetesTracker.daos;


import com.tp.DiabetesTracker.exceptions.*;
import com.tp.DiabetesTracker.models.BloodSugarRecord;
import com.tp.DiabetesTracker.models.FoodItem;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import java.sql.Date;
import java.time.LocalDate;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class FoodItemPostgresDaoTests {


    @Autowired
    FoodItemDao toTest;

    @Autowired
    JdbcTemplate template;

    @BeforeEach
    public void setup() {
        template.update("TRUNCATE \"FoodItems\" RESTART IDENTITY");

        template.update("INSERT INTO public.\"FoodItems\"(\n" +
                "\t\"Name\", \"Carbs\", \"Fat\", \"Calories\", \"Protein\", \"Fiber\", \"MealId\", \"Quantity\", \"Date\")\n" +
                "\tVALUES ('Apple', '14', '0', '54', '0', '3', '1', '1', CURRENT_DATE)");
    }

    @Test
    public void addFoodItemGoldenPathTest() {


        FoodItem item = new FoodItem();
        item.setName("Banana");
        item.setCarbs(21);
        item.setFat(4);
        item.setCalories(68);
        item.setProtein(4);
        item.setFiber(4);
        item.setMealId(2);
        item.setQuantity(2.0);
        item.setDate(LocalDate.of(2021, 2, 12));


        FoodItem returned = null;
        try {
            returned = toTest.addFoodItem(item);
        } catch (InvalidFoodNameException | InvalidCarbsException | InvalidCaloriesException | InvalidQuantityException | InvalidProteinException | InvalidFiberException | InvalidMealIdException | InvalidFatException | InvalidDateException e) {
            e.getMessage();
        }

        item.setName("Banana");
        item.setCarbs(21);
        item.setFat(4);
        item.setCalories(68);
        item.setProtein(4);
        item.setFiber(4);
        item.setMealId(2);
        item.setQuantity(2.0);
        item.setDate(LocalDate.of(2021, 2, 12));

        assertEquals("Banana", returned.getName());
        assertEquals(21, returned.getCarbs());
        assertEquals(2.0, returned.getQuantity());
        assertEquals(4, returned.getProtein());
        assertEquals(4, returned.getFiber());
        assertEquals(2, returned.getMealId());
        assertEquals(4, returned.getFat());
        assertEquals(LocalDate.of(2021, 2, 12), returned.getDate());
        assertEquals(68, returned.getCalories());

        List<FoodItem> allItems = toTest.getAllItems();

//        assertEquals("Banana", allItems.get(1).getName());
//        assertEquals(21, allItems.get(1).getCarbs());
//        assertEquals(2.0, allItems.get(1).getQuantity());
//        assertEquals(4, allItems.get(1).getProtein());
//        assertEquals(4, allItems.get(1).getFiber());
//        assertEquals(2, allItems.get(1).getMealId());
//        assertEquals(4, allItems.get(1).getFat());
//        assertEquals(LocalDate.of(2021, 2, 12), allItems.get(1).getDate());
//        assertEquals(68, allItems.get(1).getCalories());
    }

}
