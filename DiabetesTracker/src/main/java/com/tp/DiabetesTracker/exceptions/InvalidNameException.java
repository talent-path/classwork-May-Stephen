package com.tp.DiabetesTracker.exceptions;

public class InvalidNameException extends Exception{

    public InvalidNameException(String msg) { super(msg);
    }
    public InvalidNameException(String msg, Throwable innerException) { super(msg);}
}
