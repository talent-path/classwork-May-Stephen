package com.tp.DiabetesTracker.exceptions;

public class InvalidQuantityException extends Exception{

    public InvalidQuantityException(String msg) { super(msg);}

    public InvalidQuantityException(String msg, Throwable innerException) {super(msg, innerException);}
}
