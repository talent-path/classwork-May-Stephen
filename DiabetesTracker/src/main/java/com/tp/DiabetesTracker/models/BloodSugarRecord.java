package com.tp.DiabetesTracker.models;

public class BloodSugarRecord {

    Integer bsValueId;
    Integer bsValue;
    String label;

    // for date and time:
    // [4:28 PM] David Smelser
    //    yeah you'd just read them independently as strings then concatenate them before parsing
    // [4:29 PM] David Smelser
    //    but on the model itself you'd have a parsed LocalDateTime object

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
