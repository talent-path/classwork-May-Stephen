package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.models.BloodSugarRecord;
import com.tp.DiabetesTracker.models.PersonalInfo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Component;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

@Component
public class BloodSugarRecordPostgresDao implements BloodSugarRecordDao {

    @Autowired
    JdbcTemplate template;


    @Override
    public BloodSugarRecord addBloodSugar(BloodSugarRecord toAdd) {
        Integer bsValueId = template.queryForObject(
                "INSERT INTO \"BloodSugarValue\" (\"BSValue\", \"Time\", \"Date\", \"Label\")\n" +
                        "VALUES (?, CURRENT_TIME, CURRENT_DATE, ?) RETURNING \"BSValueId\";",
                new BSValueIDMapper(),
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



    class BloodSugarMapper implements RowMapper<BloodSugarRecord> {

        @Override
        public BloodSugarRecord mapRow(ResultSet resultSet, int i) throws SQLException {
            BloodSugarRecord mappedRecord = new BloodSugarRecord();
            mappedRecord.setbsValueId(resultSet.getInt("BSValueId"));
            mappedRecord.setbsValue(resultSet.getInt("BSValue"));
            mappedRecord.setLabel(resultSet.getString("Label"));


            return mappedRecord;
        }
    }

    class BSValueIDMapper implements RowMapper<Integer> {

        @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("BSValueId");
        }
    }




}
