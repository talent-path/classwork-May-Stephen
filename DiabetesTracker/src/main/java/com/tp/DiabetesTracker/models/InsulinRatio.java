package com.tp.DiabetesTracker.models;

import java.sql.Time;
import java.time.LocalTime;

public class InsulinRatio {
    Integer ratioId;
    Time start;
    Time end;
    Integer ratioFactor;

    public Time getStart() {
        return start;
    }

    public void setStart(Time start) {
        this.start = start;
    }

    public Time getEnd() {
        return end;
    }

    public void setEnd(Time end) {
        this.end = end;
    }



    public Integer getRatioId() {
        return ratioId;
    }

    public void setRatioId(Integer ratioId) {
        this.ratioId = ratioId;
    }



    public InsulinRatio(InsulinRatio toCopy) {
    }

    public InsulinRatio() {

    }

    public Integer getRatioFactor() {
        return ratioFactor;
    }

    public void setRatioFactor(Integer ratioFactor) {
        this.ratioFactor = ratioFactor;
    }


}
