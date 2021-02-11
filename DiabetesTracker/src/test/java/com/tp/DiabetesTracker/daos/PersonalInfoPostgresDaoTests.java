package com.tp.DiabetesTracker.daos;


import com.tp.DiabetesTracker.exceptions.*;
import com.tp.DiabetesTracker.models.PersonalInfo;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;
import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class PersonalInfoPostgresDaoTests {

    @Autowired
    PersonalInfoDao infoTest;

    @Autowired
    JdbcTemplate template;


    @BeforeEach
    public void setup(){
        template.update("TRUNCATE \"PersonalInfo\" RESTART IDENTITY;");

    }


    @Test
    public void addPersonalInfoGoldenPathTest() {
        PersonalInfo info = new PersonalInfo();
        info.setName("Stephen");
        info.setMinBS(70);
        info.setMaxBS(150);
        info.setWeight(185);
        info.setHeight(67);

        PersonalInfo returned = null;
            try {
                returned = infoTest.addInfo(info);
            }
            catch ( InvalidNameException e) {
                e.getMessage();
            }
            catch ( InvalidMinBSException e) {
                e.getMessage();
            }
            catch ( InvalidMaxBSException e) {
                e.getMessage();
            }
            catch ( InvalidWeightException e) {
                e.getMessage();
            }
            catch ( InvalidHeightException e) {
                e.getMessage();
            }

            assertEquals("Stephen", returned.getName());
            assertEquals(70, returned.getMinBS());
            assertEquals(150, returned.getMaxBS());
            assertEquals(185, returned.getWeight());
            assertEquals(67, returned.getHeight());
    }
}
