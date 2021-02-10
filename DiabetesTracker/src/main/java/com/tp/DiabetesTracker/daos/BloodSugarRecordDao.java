package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.models.BloodSugarRecord;
import com.tp.DiabetesTracker.models.PersonalInfo;

import java.util.List;


// need to separate BloodSugarRecord and PersonalInfo Dao's as well as Postgress Daos and controllers
public interface BloodSugarRecordDao {
    BloodSugarRecord addBloodSugar(BloodSugarRecord bg);

    public List<BloodSugarRecord> getAllRecords();


}
