package com.tp.DiabetesTracker.models;

import java.sql.Time;
import java.time.LocalDate;
import java.time.LocalTime;
import java.util.Date;

public class BloodSugarRecord {

    Integer bsValueId;
    Integer bsValue;
    String label;
    LocalDate date;
    LocalTime time;


    public LocalDate getDate() {
        return date;
    }

    public void setDate(LocalDate date) {
        this.date = date;
    }

    public LocalTime getTime() {
        return time;
    }

    public void setTime(LocalTime time) {
        this.time = time;
    }


    public BloodSugarRecord() {
        LocalDate date = LocalDate.now();
    }

    public BloodSugarRecord(BloodSugarRecord toAdd) {
    }


    public Integer getbsValueId() {
        return bsValueId;
    }

    public void setbsValueId(Integer bsValueId) {
        this.bsValueId = bsValueId;
    }

    public Integer getbsValue() {
        return bsValue;
    }

    public void setbsValue(Integer bsValue) {
        this.bsValue = bsValue;
    }

    public String getLabel() {
        return label;
    }

    public void setLabel(String label) {
        this.label = label;
    }


}
