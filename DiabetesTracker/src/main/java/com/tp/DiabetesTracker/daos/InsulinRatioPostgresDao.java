package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.daos.mappers.InsulinRatioMapper;
import com.tp.DiabetesTracker.daos.mappers.IntegerMapper;
import com.tp.DiabetesTracker.exceptions.InvalidRatioValueException;
import com.tp.DiabetesTracker.exceptions.InvalidTimeException;
import com.tp.DiabetesTracker.models.InsulinRatio;
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
public class InsulinRatioPostgresDao implements InsulinRatioDao {


    @Autowired
    JdbcTemplate template;


    @Override
    public InsulinRatio addRatio(InsulinRatio toAdd) throws InvalidRatioValueException, InvalidTimeException {
        if (toAdd.getRatioFactor() == null) throw new InvalidRatioValueException("Invalid ratio factor entered");
        if (toAdd.getStart() == null) throw new InvalidTimeException("Invalid start time entered.");
        if (toAdd.getEnd() == null) throw new InvalidTimeException("Invalid end time entered.");

        Integer ratioId = template.queryForObject(
                "INSERT INTO public.\"InsulinRatios\"(\n" +
                        "\t\"StartTime\", \"EndTime\", \"RatioFactor\")\n" +
                        "\tVALUES (?, ?, ?) RETURNING \"RatioId\";",
                    new IntegerMapper("RatioId"),
                    toAdd.getStart(),
                    toAdd.getEnd(),
                    toAdd.getRatioFactor());

        return toAdd;

        }

   @Override
   public List<InsulinRatio> getAllRatios() {
    List<InsulinRatio> allRatios = template.query("SELECT * FROM \"InsulinRatios\"", new InsulinRatioMapper());

    return allRatios;
   }










}

