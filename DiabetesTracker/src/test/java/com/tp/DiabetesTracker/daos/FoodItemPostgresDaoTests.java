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
import static org.junit.jupiter.api.Assertions.assertThrows;

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

    }

//    @Test
//    public void addBloodSugarRecordNullValue() {
//        BloodSugarRecord record = new BloodSugarRecord();
//        record.setbsValue(null);
//        record.setLabel("Snack");
//
//        assertThrows(InvalidBSValueException.class, () -> toTest.addBloodSugar(record));
//    }

    @Test
    public void addFoodItemNullNameTest() {
        FoodItem item = new FoodItem();
        item.setName(null);
        item.setCarbs(21);
        item.setFat(4);
        item.setCalories(68);
        item.setProtein(4);
        item.setFiber(4);
        item.setMealId(2);
        item.setQuantity(2.0);
        item.setDate(LocalDate.of(2021, 2, 12));

        assertThrows(InvalidFoodNameException.class, () -> toTest.addFoodItem(item));
    }

    @Test
    public void addFoodItemNullCarbsTest() {
        FoodItem item = new FoodItem();
        item.setName("Banana");
        item.setCarbs(null);
        item.setFat(4);
        item.setCalories(68);
        item.setProtein(4);
        item.setFiber(4);
        item.setMealId(2);
        item.setQuantity(2.0);
        item.setDate(LocalDate.of(2021, 2, 12));

        assertThrows(InvalidCarbsException.class, () -> toTest.addFoodItem(item));
    }

    @Test
    public void addFoodItemNullFatTest() {
        FoodItem item = new FoodItem();
        item.setName("Banana");
        item.setCarbs(21);
        item.setFat(null);
        item.setCalories(68);
        item.setProtein(4);
        item.setFiber(4);
        item.setMealId(2);
        item.setQuantity(2.0);
        item.setDate(LocalDate.of(2021, 2, 12));

        assertThrows(InvalidFatException.class, () -> toTest.addFoodItem(item));
    }

    @Test
    public void addFoodItemNullCaloriesTest() {
        FoodItem item = new FoodItem();
        item.setName("Banana");
        item.setCarbs(21);
        item.setFat(4);
        item.setCalories(null);
        item.setProtein(4);
        item.setFiber(4);
        item.setMealId(2);
        item.setQuantity(2.0);
        item.setDate(LocalDate.of(2021, 2, 12));

        assertThrows(InvalidCaloriesException.class, () -> toTest.addFoodItem(item));
    }

    @Test
    public void addFoodItemNullProteinTest() {
        FoodItem item = new FoodItem();
        item.setName("Banana");
        item.setCarbs(21);
        item.setFat(4);
        item.setCalories(68);
        item.setProtein(null);
        item.setFiber(4);
        item.setMealId(2);
        item.setQuantity(2.0);
        item.setDate(LocalDate.of(2021, 2, 12));

        assertThrows(InvalidProteinException.class, () -> toTest.addFoodItem(item));
    }

    @Test
    public void addFoodItemNullFiberTest() {
        FoodItem item = new FoodItem();
        item.setName("Banana");
        item.setCarbs(21);
        item.setFat(4);
        item.setCalories(68);
        item.setProtein(4);
        item.setFiber(null);
        item.setMealId(2);
        item.setQuantity(2.0);
        item.setDate(LocalDate.of(2021, 2, 12));

        assertThrows(InvalidFiberException.class, () -> toTest.addFoodItem(item));
    }

    @Test
    public void addFoodItemNullMealIdTest() {
        FoodItem item = new FoodItem();
        item.setName("Banana");
        item.setCarbs(21);
        item.setFat(4);
        item.setCalories(68);
        item.setProtein(4);
        item.setFiber(4);
        item.setMealId(null);
        item.setQuantity(2.0);
        item.setDate(LocalDate.of(2021, 2, 12));

        assertThrows(InvalidMealIdException.class, () -> toTest.addFoodItem(item));
    }

    @Test
    public void addFoodItemNullQuantityTest() {
        FoodItem item = new FoodItem();
        item.setName("Banana");
        item.setCarbs(21);
        item.setFat(4);
        item.setCalories(68);
        item.setProtein(4);
        item.setFiber(4);
        item.setMealId(2);
        item.setQuantity(null);
        item.setDate(LocalDate.of(2021, 2, 12));

        assertThrows(InvalidQuantityException.class, () -> toTest.addFoodItem(item));
    }

    @Test
    public void addFoodItemNullDateTest() {
        FoodItem item = new FoodItem();
        item.setName("Banana");
        item.setCarbs(21);
        item.setFat(4);
        item.setCalories(68);
        item.setProtein(4);
        item.setFiber(4);
        item.setMealId(2);
        item.setQuantity(2.0);
        item.setDate(null);

        assertThrows(InvalidDateException.class, () -> toTest.addFoodItem(item));
    }
}
