package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.daos.mappers.IntegerMapper;
import com.tp.DiabetesTracker.models.PersonalInfo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Component;

import java.sql.ResultSet;
import java.sql.SQLException;

@Component
@Profile({"production", "daoTesting"})
public class PersonalInfoPostgresDao implements PersonalInfoDao {

    @Autowired
    private JdbcTemplate template;


    @Override
    public PersonalInfo addInfo(PersonalInfo toAdd) {
        Integer userId = template.queryForObject(
                "INSERT INTO public.\"PersonalInfo\"(\n" +
                        "\t\"name\", \"Height(in.)\", \"Weight(lbs.)\", \"MinBS\", \"MaxBS\")\n" +
                        "\tVALUES (?, ?, ?, ?, ?) RETURNING \"UserId\";",
                new IntegerMapper("UserOd"),
                toAdd.getName(),
                toAdd.getHeight(),
                toAdd.getWeight());
                toAdd.getMinBS();
                toAdd.getMaxBS();

        toAdd.setUserId(userId);

        return toAdd;

    }




}
