package com.tp.DiabetesTracker.exceptions;

public class InvalidFoodNameException extends Exception{

    public InvalidFoodNameException(String msg) {super(msg);}

    public InvalidFoodNameException(String msg, Throwable innerException) {super(msg, innerException);}
}
