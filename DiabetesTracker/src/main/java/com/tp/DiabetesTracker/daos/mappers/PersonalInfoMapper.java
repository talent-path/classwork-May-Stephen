package com.tp.DiabetesTracker.daos.mappers;

import com.tp.DiabetesTracker.models.PersonalInfo;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

public class PersonalInfoMapper implements RowMapper<PersonalInfo> {

    @Override
    public PersonalInfo mapRow(ResultSet resultSet, int i) throws SQLException {
        PersonalInfo mappedInfo = new PersonalInfo();
        mappedInfo.setName(resultSet.getString("name"));
        mappedInfo.setHeight(resultSet.getInt("Height(in.)"));
        mappedInfo.setWeight(resultSet.getInt("Weight(lbs.)"));
        mappedInfo.setMinBS(resultSet.getInt("MinBS"));
        mappedInfo.setMaxBS(resultSet.getInt("MaxBS"));

        return mappedInfo;
    }
}
