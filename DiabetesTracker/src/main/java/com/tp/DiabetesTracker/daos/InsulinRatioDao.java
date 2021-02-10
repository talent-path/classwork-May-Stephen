package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.models.InsulinRatio;

import java.util.List;

public interface InsulinRatioDao {

    InsulinRatio addRatio(InsulinRatio toAdd);

    List<InsulinRatio> getAllRatios();
}
