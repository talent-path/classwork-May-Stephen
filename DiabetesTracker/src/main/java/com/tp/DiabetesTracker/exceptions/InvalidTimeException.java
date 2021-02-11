package com.tp.DiabetesTracker.exceptions;

public class InvalidTimeException extends Exception{

    public InvalidTimeException(String msg) { super(msg);}

    public InvalidTimeException(String msg, Throwable innerException) { super(msg, innerException);}
}
