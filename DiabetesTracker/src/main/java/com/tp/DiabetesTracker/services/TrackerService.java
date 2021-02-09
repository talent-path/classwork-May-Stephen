package com.tp.DiabetesTracker.services;

import com.tp.DiabetesTracker.daos.TrackerDao;
import com.tp.DiabetesTracker.models.BloodSugarRecord;
import com.tp.DiabetesTracker.models.PersonalInfo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;


@Service
public class TrackerService {

    @Autowired
    TrackerDao dao;

    public BloodSugarRecord addBloodSugar(BloodSugarRecord bg) {


        return dao.addBloodSugar(bg);
    }

    public List<BloodSugarRecord> getAllRecords() {
        return dao.getAllRecords();
    }

    public PersonalInfo addInfo(PersonalInfo toAdd) {
        return dao.addInfo(toAdd);
    }
}
