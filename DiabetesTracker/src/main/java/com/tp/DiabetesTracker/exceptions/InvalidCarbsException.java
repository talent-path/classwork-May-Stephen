package com.tp.DiabetesTracker.exceptions;


public class InvalidCarbsException extends Exception{

    public InvalidCarbsException(String msg) {super(msg);}

    public InvalidCarbsException(String msg, Throwable innerException) {super(msg, innerException);}
}
