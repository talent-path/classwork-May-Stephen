package com.tp.DiabetesTracker.exceptions;

public class InvalidFatException extends Exception{

    public InvalidFatException(String msg) {super(msg);}

    public InvalidFatException(String msg, Throwable innerException) { super(msg, innerException);}
}
