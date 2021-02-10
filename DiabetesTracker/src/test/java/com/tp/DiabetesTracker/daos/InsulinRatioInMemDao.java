package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.daos.mappers.InsulinRatioMapper;
import com.tp.DiabetesTracker.daos.mappers.IntegerMapper;
import com.tp.DiabetesTracker.models.InsulinRatio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

import java.util.List;


@Component
@Profile("serviceTest")
public class InsulinRatioInMemDao implements InsulinRatioDao{

    @Autowired
    private JdbcTemplate template;


    @Override
    public InsulinRatio addRatio(InsulinRatio toAdd) {
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
