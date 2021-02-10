package com.tp.DiabetesTracker.daos.mappers;

import com.tp.DiabetesTracker.models.InsulinRatio;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

public class InsulinRatioMapper implements RowMapper<InsulinRatio> {
    @Override
    public InsulinRatio mapRow(ResultSet resultSet, int i) throws SQLException {
        InsulinRatio mappedInsulinRatio = new InsulinRatio();
        mappedInsulinRatio.setStart(resultSet.getTime("StartTime"));
        mappedInsulinRatio.setEnd(resultSet.getTime("EndTime"));
        mappedInsulinRatio.setRatioFactor(resultSet.getInt("RatioFactor"));

        return mappedInsulinRatio;
    }


}
