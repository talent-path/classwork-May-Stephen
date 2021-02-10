package com.tp.DiabetesTracker.daos.mappers;

import com.tp.DiabetesTracker.models.BloodSugarRecord;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

public class BloodSugarMapper implements RowMapper<BloodSugarRecord> {

    @Override
    public BloodSugarRecord mapRow(ResultSet resultSet, int i) throws SQLException {
        BloodSugarRecord mappedRecord = new BloodSugarRecord();
        mappedRecord.setbsValueId(resultSet.getInt("BSValueId"));
        mappedRecord.setbsValue(resultSet.getInt("BSValue"));
        mappedRecord.setLabel(resultSet.getString("Label"));


        return mappedRecord;
    }
}
