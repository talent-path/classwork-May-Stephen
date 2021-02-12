package com.tp.DiabetesTracker.controllers;


import com.tp.DiabetesTracker.exceptions.*;
import com.tp.DiabetesTracker.models.PersonalInfo;
import com.tp.DiabetesTracker.services.BloodSugarManagementService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api")
public class PersonalInfoController {

    @Autowired
    BloodSugarManagementService service;

    @PostMapping("/info")
    public ResponseEntity addInfo(@RequestBody PersonalInfo toAdd) {
        PersonalInfo enteredInfo = null;
        try {
            enteredInfo = service.addInfo(toAdd);
        } catch (InvalidMinBSException | InvalidHeightException | InvalidNameException | InvalidWeightException | InvalidMaxBSException e) {
            e.printStackTrace();
        }
        return ResponseEntity.ok(enteredInfo);
    }

    @PutMapping("/editinfo/{userId}")
    public ResponseEntity editWeight(@RequestBody PersonalInfo toEdit) {
        PersonalInfo editInfo = service.editInfo(toEdit);
        return ResponseEntity.ok(editInfo);
    }
}
