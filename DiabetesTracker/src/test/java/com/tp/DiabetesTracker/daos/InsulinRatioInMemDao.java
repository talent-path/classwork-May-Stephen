package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.daos.mappers.InsulinRatioMapper;
import com.tp.DiabetesTracker.daos.mappers.IntegerMapper;
import com.tp.DiabetesTracker.models.BloodSugarRecord;
import com.tp.DiabetesTracker.models.InsulinRatio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;


@Component
@Profile("serviceTest")
public class InsulinRatioInMemDao implements InsulinRatioDao{

    @Autowired
    JdbcTemplate template;



    List<InsulinRatio> allRatios = new ArrayList<>();


    @Override
    public InsulinRatio addRatio(InsulinRatio toAdd) {
        int id = 0;

        for(InsulinRatio toCheck : allRatios) {
            if(toCheck.getRatioId() > id) {
                id = toCheck.getRatioId();
            }
        }
        id++;

        InsulinRatio copy = new InsulinRatio(toAdd);

        allRatios.add(copy);
        return copy;

    }


    @Override
    public List<InsulinRatio> getAllRatios() {
        List<InsulinRatio> copyList = new ArrayList<>();

        for(InsulinRatio toCopy : allRatios) {
            copyList.add(new InsulinRatio(toCopy));

        }
        return copyList;
    }

}
