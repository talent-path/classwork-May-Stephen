package com.tp.DiabetesTracker.exceptions;

public class InvalidMealIdException extends Exception{

    public InvalidMealIdException(String msg) {super(msg);}

    public InvalidMealIdException(String msg, Throwable innerException) {super(msg, innerException);}
}
