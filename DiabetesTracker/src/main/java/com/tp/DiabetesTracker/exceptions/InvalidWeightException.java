package com.tp.DiabetesTracker.exceptions;

public class InvalidWeightException extends Exception{

    public InvalidWeightException(String msg) {super(msg);}

    public InvalidWeightException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}