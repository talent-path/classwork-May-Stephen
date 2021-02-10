package com.tp.DiabetesTracker.controllers;


import com.tp.DiabetesTracker.models.PersonalInfo;
import com.tp.DiabetesTracker.services.BloodSugarManagementService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api")
public class PersonalInfoController {

    @Autowired
    BloodSugarManagementService service;

    @PostMapping("/info")
    public ResponseEntity addInfo(@RequestBody PersonalInfo toAdd) {
        PersonalInfo enteredInfo = service.addInfo(toAdd);
        return ResponseEntity.ok(enteredInfo);
    }
}
