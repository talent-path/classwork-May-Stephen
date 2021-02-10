package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.models.InsulinRatio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Component;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;


@Component
public class InsulinRatioPostgresDao implements InsulinRatioDao {


    @Autowired
    JdbcTemplate template;


    @Override
    public InsulinRatio addRatio(InsulinRatio toAdd) {
        Integer ratioId = template.queryForObject(
                "INSERT INTO public.\"InsulinRatios\"(\n" +
                        "\t\"StartTime\", \"EndTime\", \"RatioFactor\")\n" +
                        "\tVALUES (?, ?, ?) RETURNING \"RatioId\";",
                    new InsulinRatioIDMapper(),
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








    class InsulinRatioMapper implements RowMapper<InsulinRatio>{
        @Override
        public InsulinRatio mapRow(ResultSet resultSet, int i) throws SQLException {
            InsulinRatio mappedInsulinRatio = new InsulinRatio();
            mappedInsulinRatio.setStart(resultSet.getTime("StartTime"));
            mappedInsulinRatio.setEnd(resultSet.getTime("EndTime"));
            mappedInsulinRatio.setRatioFactor(resultSet.getInt("RatioFactor"));

            return mappedInsulinRatio;
        }


    }

    class InsulinRatioIDMapper implements RowMapper<Integer> {
    @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("RatioId");
    }

    }
}

