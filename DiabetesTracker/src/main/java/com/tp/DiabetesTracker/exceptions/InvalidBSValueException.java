package com.tp.DiabetesTracker.exceptions;

public class InvalidBSValueException extends Exception{

    public InvalidBSValueException(String msg) { super(msg);}

    public InvalidBSValueException(String msg, Throwable innerException) { super(msg, innerException);}
}
