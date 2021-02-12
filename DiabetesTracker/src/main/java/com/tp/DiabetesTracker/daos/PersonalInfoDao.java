package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.exceptions.*;
import com.tp.DiabetesTracker.models.PersonalInfo;

public interface PersonalInfoDao {

    PersonalInfo addInfo(PersonalInfo toAdd) throws InvalidNameException, InvalidHeightException, InvalidWeightException, InvalidMinBSException, InvalidMaxBSException;



    PersonalInfo editWeight(PersonalInfo toEdit) throws InvalidWeightException;
}
