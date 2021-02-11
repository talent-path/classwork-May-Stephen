package com.tp.DiabetesTracker.exceptions;

public class InvalidHeightException extends Exception{
    public InvalidHeightException(String msg) { super(msg);}

    public InvalidHeightException(String msg, Throwable innerException) { super(msg, innerException);}
}