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
public class PostgresTrackerDao implements TrackerDao {

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

    @Override
    public PersonalInfo addInfo(PersonalInfo toAdd) {
        Integer userId = template.queryForObject(
                "INSERT INTO public.\"PersonalInfo\"(\n" +
                        "\t\"name\", \"Height(in.)\", \"Weight(lbs.)\")\n" +
                        "\tVALUES (?, ?, ?) RETURNING \"UserId\";",
                new PersonalInfoIDMapper(),
                toAdd.getName(),
                toAdd.getHeight(),
                toAdd.getWeight());

        toAdd.setUserId(userId);

        return toAdd;

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

    class PersonalInfoMapper implements RowMapper<PersonalInfo> {

        @Override
        public PersonalInfo mapRow(ResultSet resultSet, int i) throws SQLException {
            PersonalInfo mappedInfo = new PersonalInfo();
            mappedInfo.setName(resultSet.getString("name"));
            mappedInfo.setHeight(resultSet.getInt("Height(in.)"));
            mappedInfo.setWeight(resultSet.getInt("Weight(lbs.)"));

            return mappedInfo;
        }
    }

    class PersonalInfoIDMapper implements RowMapper<Integer> {
        @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("UserId");
        }
    }
}
