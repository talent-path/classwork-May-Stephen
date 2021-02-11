package com.tp.DiabetesTracker.daos;


import com.tp.DiabetesTracker.models.BloodSugarRecord;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

import java.util.*;

@Component
@Profile("serviceTest")
public class BloodSugarRecordInMemDao implements BloodSugarRecordDao{

    @Autowired
    JdbcTemplate template;


    List<BloodSugarRecord> allRecords = new ArrayList<>();

    @Override
    public BloodSugarRecord addBloodSugar(BloodSugarRecord toAdd) {
        int id = 0;

        for(BloodSugarRecord toCheck : allRecords) {
            if(toCheck.getbsValueId() > id) {
                id = toCheck.getbsValueId();
            }
        }

        id++;

            BloodSugarRecord copy = new BloodSugarRecord(toAdd);

            allRecords.add(copy);
            return copy;
    }

    @Override
    public List<BloodSugarRecord> getAllRecords() {
        List<BloodSugarRecord> copyList = new ArrayList<>();

        for(BloodSugarRecord toCopy : allRecords) {
            copyList.add(new BloodSugarRecord(toCopy));
        }

        return copyList;
    }




}
