package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.exceptions.InvalidRatioValueException;
import com.tp.DiabetesTracker.exceptions.InvalidTimeException;
import com.tp.DiabetesTracker.models.InsulinRatio;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;
import static org.junit.jupiter.api.Assertions.*;

import java.sql.Time;
import java.util.List;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class InsulinRatioPostgresDaoTests {

    @Autowired
    InsulinRatioDao toTest;

    @Autowired
    JdbcTemplate template;


    @BeforeEach
    public void setup() {
        template.update("TRUNCATE \"BloodSugarValue\", \"InsulinRatios\", \"PersonalInfo\" RESTART IDENTITY");

        template.update("INSERT INTO public.\"InsulinRatios\"(\n" +
                "\t\"StartTime\", \"EndTime\", \"RatioFactor\")\n" +
                "\tVALUES ('01:00', '09:00', '15');");

    }


    @Test
    public void addInsulinRatioGoldenPathTest() {
        InsulinRatio ratio = new InsulinRatio();
        ratio.setRatioId(2);
        ratio.setStart(Time.valueOf("09:00:00"));
        ratio.setEnd(Time.valueOf("17:00:00"));
        ratio.setRatioFactor(10);

        InsulinRatio returned = null;
        try {
            returned = toTest.addRatio(ratio);
        } catch (InvalidRatioValueException e) {
            e.getMessage();
        } catch (InvalidTimeException e) {
            e.getMessage();
        }

        assertEquals(2, returned.getRatioId());
        assertEquals(Time.valueOf("09:00:00"), returned.getStart());
        assertEquals(Time.valueOf("17:00:00"), returned.getEnd());
        assertEquals(10, returned.getRatioFactor());

        List<InsulinRatio> allRatios = toTest.getAllRatios();

//        assertEquals(2, allRatios.get(1).getRatioId());
//        assertEquals(Time.valueOf("09:00:00"), allRatios.get(1).getStart());
//        assertEquals(Time.valueOf("17:00:00"), allRatios.get(1).getEnd());
//        assertEquals(10, allRatios.get(1).getRatioFactor());

    }

    @Test
    public void addRatioInvalidRatioValueTest() {

        InsulinRatio ratio = new InsulinRatio();

        ratio.setRatioId(2);
        ratio.setRatioFactor(null);
        ratio.setStart(Time.valueOf("09:00:00"));
        ratio.setEnd(Time.valueOf("12:00:00"));

        assertThrows(InvalidRatioValueException.class, () -> toTest.addRatio(ratio));
    }

    @Test
    public void addRatioInvalidStartTimeTest() {

        InsulinRatio ratio = new InsulinRatio();

        ratio.setRatioId(2);
        ratio.setRatioFactor(15);
        ratio.setStart(null);
        ratio.setEnd(Time.valueOf("12:00:00"));

        assertThrows(InvalidTimeException.class, () -> toTest.addRatio(ratio));
    }

    @Test
    public void addRatioInvalidEndTimeTest() {

        InsulinRatio ratio = new InsulinRatio();

        ratio.setRatioId(2);
        ratio.setRatioFactor(15);
        ratio.setStart(Time.valueOf("09:00:00"));
        ratio.setEnd(null);

        assertThrows(InvalidTimeException.class, () -> toTest.addRatio(ratio));
    }
}
