package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.exceptions.InvalidBSValueException;
import com.tp.DiabetesTracker.exceptions.InvalidLabelException;
import com.tp.DiabetesTracker.models.BloodSugarRecord;

import java.util.List;



public interface BloodSugarRecordDao {
    BloodSugarRecord addBloodSugar(BloodSugarRecord bg) throws InvalidLabelException, InvalidBSValueException;

    List<BloodSugarRecord> getAllRecords();

    List<BloodSugarRecord> getRecordsByDay();
}
