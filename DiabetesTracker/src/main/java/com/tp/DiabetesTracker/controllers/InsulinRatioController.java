package com.tp.DiabetesTracker.controllers;



import com.tp.DiabetesTracker.models.InsulinRatio;
import com.tp.DiabetesTracker.services.BloodSugarManagementService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api")
public class InsulinRatioController {

    @Autowired
    BloodSugarManagementService service;

    @PostMapping("/addratio")
    public ResponseEntity addRatio(@RequestBody InsulinRatio toAdd){

        InsulinRatio enteredRatio = service.addRatio(toAdd);
        return ResponseEntity.ok(enteredRatio);

    }

    @GetMapping("/ratios")
    public List<InsulinRatio> getAllRatios() {
        return service.getAllRatios();
    }


}
