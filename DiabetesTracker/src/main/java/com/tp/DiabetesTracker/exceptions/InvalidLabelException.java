package com.tp.DiabetesTracker.exceptions;

public class InvalidLabelException extends Exception{

    public InvalidLabelException(String msg) { super(msg);}

    public InvalidLabelException(String msg, Throwable innerException) { super(msg, innerException);}
}
