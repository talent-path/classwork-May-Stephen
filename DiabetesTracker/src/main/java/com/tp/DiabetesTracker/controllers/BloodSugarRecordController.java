package com.tp.DiabetesTracker.controllers;


import com.tp.DiabetesTracker.exceptions.InvalidBSValueException;
import com.tp.DiabetesTracker.exceptions.InvalidLabelException;
import com.tp.DiabetesTracker.models.BloodSugarRecord;
import com.tp.DiabetesTracker.services.BloodSugarManagementService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/api")
public class BloodSugarRecordController {

    @Autowired
    BloodSugarManagementService service;


    @PostMapping("/bloodsugar")
    public ResponseEntity addBG(@RequestBody BloodSugarRecord toAdd) {

        BloodSugarRecord enteredBG = null;
        try {
            enteredBG = service.addBloodSugar(toAdd);
        } catch (InvalidLabelException e) {
            e.getMessage();
        } catch (InvalidBSValueException e) {
            e.getMessage();
        }
        return ResponseEntity.ok(enteredBG);

    }

    @GetMapping("/allrecords")
    public List<BloodSugarRecord> getAllRecords() {
        return service.getAllRecords();
    }


    @GetMapping("/day")
    public List<BloodSugarRecord> getRecordByDate() {
        return service.getRecordByDate();
    }

}



