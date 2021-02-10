package com.tp.DiabetesTracker.models;

import java.sql.Time;
import java.time.LocalTime;

public class InsulinRatio {
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

    public Integer getRatioFactor() {
        return ratioFactor;
    }

    public void setRatioFactor(Integer ratioFactor) {
        this.ratioFactor = ratioFactor;
    }


}
