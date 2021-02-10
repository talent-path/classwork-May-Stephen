package com.tp.DiabetesTracker.models;

public class PersonalInfo {

    Integer userId;
    String name;
    Integer height;
    Integer weight;
    Integer minBS;
    Integer maxBS;

    public Integer getMinBS() {
        return minBS;
    }

    public void setMinBS(Integer minBS) {
        this.minBS = minBS;
    }

    public Integer getMaxBS() {
        return maxBS;
    }

    public void setMaxBS(Integer maxBS) {
        this.maxBS = maxBS;
    }

    public Integer getUserId() {
        return userId;
    }

    public void setUserId(Integer userId) {
        this.userId = userId;
    }


    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Integer getHeight() {
        return height;
    }

    public void setHeight(Integer height) {
        this.height = height;
    }

    public Integer getWeight() {
        return weight;
    }

    public void setWeight(Integer weight) {
        this.weight = weight;
    }


}
