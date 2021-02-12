package com.tp.DiabetesTracker.exceptions;



public class InvalidCaloriesException extends Exception{

    public InvalidCaloriesException(String msg) { super(msg);}

    public InvalidCaloriesException(String msg, Throwable innerException) {super(msg, innerException);}


}
