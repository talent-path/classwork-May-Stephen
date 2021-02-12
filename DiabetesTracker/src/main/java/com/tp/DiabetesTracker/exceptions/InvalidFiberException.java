package com.tp.DiabetesTracker.exceptions;

public class InvalidFiberException extends Exception{

    public InvalidFiberException(String msg) {super(msg);}

    public InvalidFiberException(String msg, Throwable innerException) {super(msg, innerException);}
}
