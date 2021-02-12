package com.tp.DiabetesTracker.exceptions;

public class InvalidDateException extends Exception{

    public InvalidDateException(String msg) {super(msg);}

    public InvalidDateException(String msg, Throwable innerException) {super(msg, innerException);}
}
