package com.tp.DiabetesTracker.exceptions;

public class InvalidRatioValueException extends Exception{

    public InvalidRatioValueException(String msg) { super(msg);}

    public InvalidRatioValueException(String msg, Throwable innerException) { super(msg, innerException);}
}