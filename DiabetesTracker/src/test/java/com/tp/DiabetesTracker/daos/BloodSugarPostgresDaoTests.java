package com.tp.DiabetesTracker.daos;

import com.tp.DiabetesTracker.exceptions.InvalidBSValueException;
import com.tp.DiabetesTracker.exceptions.InvalidLabelException;
import com.tp.DiabetesTracker.models.BloodSugarRecord;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.jdbc.core.JdbcTemplate;

import java.util.List;

import static org.junit.jupiter.api.Assertions.*;


@SpringBootTest
@ActiveProfiles("daoTesting")
public class BloodSugarPostgresDaoTests {

    @Autowired
    BloodSugarRecordDao toTest;

    @Autowired
    JdbcTemplate template;


    @BeforeEach
    public void setup(){
        template.update("TRUNCATE \"BloodSugarValue\", \"InsulinRatios\", \"PersonalInfo\" RESTART IDENTITY");

        template.update("INSERT INTO public.\"BloodSugarValue\"(\n" +
                "\t\"BSValue\", \"Time\", \"Date\", \"Label\")\n" +
                "\tVALUES ('100', CURRENT_TIME, CURRENT_DATE, 'Snack');");

    }


    @Test
    public void addBloodSugarRecordGoldenPathTest() {

        BloodSugarRecord record = new BloodSugarRecord();
        record.setbsValue(140);
        record.setLabel("After lunch");

        BloodSugarRecord returned = null;
        try {
            returned = toTest.addBloodSugar(record);
        } catch (InvalidLabelException e) {
            e.getMessage();
        } catch (InvalidBSValueException e) {
            e.getMessage();
        }

        assertEquals(2, returned.getbsValueId());
        assertEquals(140, returned.getbsValue());
        assertEquals("After lunch", returned.getLabel());

        List<BloodSugarRecord> allRecords = toTest.getAllRecords();

        assertEquals(2, allRecords.get(1).getbsValueId());
        assertEquals(140, allRecords.get(1).getbsValue());
        assertEquals("After lunch", allRecords.get(1).getLabel());

    }


    @Test
    public void addBloodSugarRecordNullValue() {
        BloodSugarRecord record = new BloodSugarRecord();
        record.setbsValue(null);
        record.setLabel("Snack");

        assertThrows(InvalidBSValueException.class, () -> toTest.addBloodSugar(record));
    }

    @Test
    public void addBloodSugarRecordNullLabel(){

        BloodSugarRecord record = new BloodSugarRecord();
        record.setbsValue(100);
        record.setLabel(null);

        assertThrows(InvalidLabelException.class, () -> toTest.addBloodSugar(record));
    }
}
