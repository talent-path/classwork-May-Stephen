package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.daos.mappers.BloodSugarMapper;
import com.tp.DiabetesTracker.daos.mappers.IntegerMapper;
import com.tp.DiabetesTracker.models.BloodSugarRecord;
import com.tp.DiabetesTracker.models.PersonalInfo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Component;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

@Component
@Profile({"production", "daoTesting"})
public class BloodSugarRecordPostgresDao implements BloodSugarRecordDao {

    @Autowired
    private JdbcTemplate template;


    @Override
    public BloodSugarRecord addBloodSugar(BloodSugarRecord toAdd) {
        Integer bsValueId = template.queryForObject(
                "INSERT INTO \"BloodSugarValue\" (\"BSValue\", \"Time\", \"Date\", \"Label\")\n" +
                        "VALUES (?, CURRENT_TIME, CURRENT_DATE, ?) RETURNING \"BSValueId\";",
                new IntegerMapper("BSValueId"),
                toAdd.getbsValue(),
                toAdd.getLabel());

        toAdd.setbsValueId(bsValueId);

        return toAdd;
    }

    @Override
    public List<BloodSugarRecord> getAllRecords() {
        List<BloodSugarRecord> allRecords = template.query("SELECT * FROM \"BloodSugarValue\"", new BloodSugarMapper());

        return allRecords;
    }






}



