package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.daos.mappers.BloodSugarMapper;
import com.tp.DiabetesTracker.daos.mappers.IntegerMapper;
import com.tp.DiabetesTracker.exceptions.InvalidBSValueException;
import com.tp.DiabetesTracker.exceptions.InvalidLabelException;
import com.tp.DiabetesTracker.models.BloodSugarRecord;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

import java.time.LocalDate;
import java.util.List;

@Component
@Profile({"production", "daoTesting"})
public class BloodSugarRecordPostgresDao implements BloodSugarRecordDao {

    @Autowired
    private JdbcTemplate template;


    @Override
    public BloodSugarRecord addBloodSugar(BloodSugarRecord toAdd) throws InvalidLabelException, InvalidBSValueException {
        if (toAdd.getLabel() == null) throw new InvalidLabelException("Invalid Label type.");
        if (toAdd.getbsValue() == null) throw new InvalidBSValueException("Invalid Blood Sugar Value.");

        Integer bsValueId = template.queryForObject(
                "INSERT INTO \"BloodSugarValue\" (\"BSValue\", \"Time\", \"Date\", \"Label\")\n" +
                        "VALUES (?, CURRENT_TIME, CURRENT_DATE, ?) RETURNING \"BSValueId\";",
                new IntegerMapper("BSValueId"),
                toAdd.getbsValue(),
                toAdd.getLabel(),
                toAdd.getDate(),
                toAdd.getTime());

        toAdd.setbsValueId(bsValueId);

        return toAdd;
    }

    @Override
    public List<BloodSugarRecord> getAllRecords() {
        List<BloodSugarRecord> allRecords = template.query("SELECT * FROM \"BloodSugarValue\"", new BloodSugarMapper());

        return allRecords;
    }


    // TODO: Update to allow for days other than today
    @Override
    public List<BloodSugarRecord> getRecordsByDate() {
        List<BloodSugarRecord> recordsByDate = template.query("SELECT *\n" +
                "\tFROM public.\"BloodSugarValue\"\n" +
                "\t\tWHERE \"Date\" = CURRENT_DATE;", new BloodSugarMapper());

        return recordsByDate;
    }


}








