package com.tp.DiabetesTracker.services;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.ActiveProfiles;

@SpringBootTest
@ActiveProfiles("serviceTest")
public class BloodSugarManagementTests {

    @Autowired
    BloodSugarManagementService toTest;
}
