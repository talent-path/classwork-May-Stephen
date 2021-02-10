package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.models.PersonalInfo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Component;

import java.sql.ResultSet;
import java.sql.SQLException;

@Component
public class PersonalInfoPostgresDao implements PersonalInfoDao {

    @Autowired
    JdbcTemplate template;


    @Override
    public PersonalInfo addInfo(PersonalInfo toAdd) {
        Integer userId = template.queryForObject(
                "INSERT INTO public.\"PersonalInfo\"(\n" +
                        "\t\"name\", \"Height(in.)\", \"Weight(lbs.)\", \"MinBS\", \"MaxBS\")\n" +
                        "\tVALUES (?, ?, ?, ?, ?) RETURNING \"UserId\";",
                new PersonalInfoPostgresDao.PersonalInfoIDMapper(),
                toAdd.getName(),
                toAdd.getHeight(),
                toAdd.getWeight());
                toAdd.getMinBS();
                toAdd.getMaxBS();

        toAdd.setUserId(userId);

        return toAdd;

    }


    class PersonalInfoMapper implements RowMapper<PersonalInfo> {

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

    class PersonalInfoIDMapper implements RowMapper<Integer> {
        @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("UserId");
        }
    }
}
