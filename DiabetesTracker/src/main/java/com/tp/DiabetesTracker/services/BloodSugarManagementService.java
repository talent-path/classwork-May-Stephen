package com.tp.DiabetesTracker.services;

import com.tp.DiabetesTracker.daos.BloodSugarRecordDao;
import com.tp.DiabetesTracker.daos.InsulinRatioDao;
import com.tp.DiabetesTracker.daos.PersonalInfoDao;
import com.tp.DiabetesTracker.exceptions.InvalidBSValueException;
import com.tp.DiabetesTracker.exceptions.InvalidLabelException;
import com.tp.DiabetesTracker.exceptions.InvalidRatioValueException;
import com.tp.DiabetesTracker.exceptions.InvalidTimeException;
import com.tp.DiabetesTracker.models.BloodSugarRecord;
import com.tp.DiabetesTracker.models.InsulinRatio;
import com.tp.DiabetesTracker.models.PersonalInfo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.Date;
import java.util.List;


@Service
public class BloodSugarManagementService {

    @Autowired
    BloodSugarRecordDao dao;

    @Autowired
    PersonalInfoDao piDao;

    @Autowired
    InsulinRatioDao RatioDao;

    public BloodSugarRecord addBloodSugar(BloodSugarRecord bg) throws InvalidLabelException, InvalidBSValueException {
        return dao.addBloodSugar(bg);
    }

    public List<BloodSugarRecord> getAllRecords() {
        return dao.getAllRecords();
    }

    public PersonalInfo addInfo(PersonalInfo toAdd) {
        return piDao.addInfo(toAdd);
    }

    public InsulinRatio addRatio(InsulinRatio toAdd) throws InvalidTimeException, InvalidRatioValueException {
        return RatioDao.addRatio(toAdd);
    }

    public List<InsulinRatio> getAllRatios() { return RatioDao.getAllRatios();
    }


}
