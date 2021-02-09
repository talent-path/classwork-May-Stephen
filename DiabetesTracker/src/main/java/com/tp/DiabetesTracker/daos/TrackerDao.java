package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.models.BloodSugarRecord;
import com.tp.DiabetesTracker.models.PersonalInfo;

import java.util.List;

public interface TrackerDao {
    BloodSugarRecord addBloodSugar(BloodSugarRecord bg);

    public List<BloodSugarRecord> getAllRecords();

    PersonalInfo addInfo(PersonalInfo toAdd);
}
