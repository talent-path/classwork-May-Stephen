package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.exceptions.InvalidRatioValueException;
import com.tp.DiabetesTracker.exceptions.InvalidTimeException;
import com.tp.DiabetesTracker.models.InsulinRatio;

import java.util.List;

public interface InsulinRatioDao {

    InsulinRatio addRatio(InsulinRatio toAdd) throws InvalidRatioValueException, InvalidTimeException;

    List<InsulinRatio> getAllRatios();
}
