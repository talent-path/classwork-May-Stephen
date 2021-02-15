package com.tp.DiabetesTracker.services;

import com.tp.DiabetesTracker.daos.BloodSugarRecordDao;
import com.tp.DiabetesTracker.daos.FoodItemDao;
import com.tp.DiabetesTracker.daos.InsulinRatioDao;
import com.tp.DiabetesTracker.daos.PersonalInfoDao;
import com.tp.DiabetesTracker.exceptions.*;
import com.tp.DiabetesTracker.models.BloodSugarRecord;
import com.tp.DiabetesTracker.models.FoodItem;
import com.tp.DiabetesTracker.models.InsulinRatio;
import com.tp.DiabetesTracker.models.PersonalInfo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;


@Service
public class BloodSugarManagementService {

    @Autowired
    BloodSugarRecordDao dao;

    @Autowired
    PersonalInfoDao piDao;

    @Autowired
    InsulinRatioDao RatioDao;

    @Autowired
    FoodItemDao foodDao;

    public BloodSugarRecord addBloodSugar(BloodSugarRecord bg) throws InvalidLabelException, InvalidBSValueException {
        return dao.addBloodSugar(bg);
    }

    public List<BloodSugarRecord> getAllRecords() {
        return dao.getAllRecords();
    }

    public PersonalInfo addInfo(PersonalInfo toAdd) throws InvalidMinBSException, InvalidNameException, InvalidWeightException, InvalidMaxBSException, InvalidHeightException {
        return piDao.addInfo(toAdd);
    }

    public InsulinRatio addRatio(InsulinRatio toAdd) throws InvalidTimeException, InvalidRatioValueException {
        return RatioDao.addRatio(toAdd);
    }

    public List<InsulinRatio> getAllRatios() { return RatioDao.getAllRatios();
    }


    public PersonalInfo editInfo(PersonalInfo toEdit) throws InvalidWeightException { return piDao.editWeight(toEdit);
    }

    public FoodItem addFoodItem(FoodItem toAdd) throws InvalidProteinException, InvalidFiberException, InvalidMealIdException, InvalidCaloriesException, InvalidQuantityException, InvalidFoodNameException, InvalidDateException, InvalidFatException, InvalidCarbsException {
        return foodDao.addFoodItem(toAdd);
    }

    public List<FoodItem> getAllItems() { return foodDao.getAllItems();
    }


    public List<BloodSugarRecord> getRecordByDate() {
        return dao.getRecordsByDate();
    }
}
