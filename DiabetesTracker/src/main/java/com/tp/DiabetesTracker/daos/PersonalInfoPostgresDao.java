package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.daos.mappers.IntegerMapper;
import com.tp.DiabetesTracker.exceptions.*;
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
    JdbcTemplate template;


    @Override
    public PersonalInfo addInfo(PersonalInfo toAdd) throws InvalidNameException, InvalidHeightException, InvalidWeightException, InvalidMinBSException, InvalidMaxBSException {
        if(toAdd.getName() == null) throw new InvalidNameException("Invalid Name provided");
        if(toAdd.getMinBS() == null) throw new InvalidMinBSException("Invalid minimum BS value provided.");
        if(toAdd.getMaxBS() == null) throw new InvalidMaxBSException("Invalid maximum BS value provided.");
        if(toAdd.getWeight() == null) throw new InvalidWeightException("Invalid weight provided.");
        if(toAdd.getHeight() == null) throw new InvalidHeightException("Invalid height provided.");


        Integer userId = template.queryForObject(
                "INSERT INTO public.\"PersonalInfo\"(\n" +
                        "\t\"name\", \"Height(in.)\", \"Weight(lbs.)\", \"MinBS\", \"MaxBS\")\n" +
                        "\tVALUES (?, ?, ?, ?, ?) RETURNING \"UserId\";",
                new IntegerMapper("UserId"),
                toAdd.getName(),
                toAdd.getHeight(),
                toAdd.getWeight(),
                toAdd.getMinBS(),
                toAdd.getMaxBS());

        toAdd.setUserId(userId);

        return toAdd;

    }


    // works, but is printing out null for all values other than weight
    // Column out of bounds exception, won't work with all other toEdit.getName(), etc.....
    @Override
    public PersonalInfo editWeight(PersonalInfo toEdit) throws InvalidWeightException {

        if(toEdit.getWeight() == null) throw new InvalidWeightException("Invalid weight provided.");
        template.update("UPDATE \"PersonalInfo\"\n" +
                        "SET \"Weight(lbs.)\" = ?\n" +
                        "WHERE \"UserId\" = '1';",
                toEdit.getWeight());


        return toEdit;
    }


}
