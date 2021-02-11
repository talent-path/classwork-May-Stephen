package com.tp.DiabetesTracker.exceptions;

public class InvalidMinBSException extends Exception{

    public InvalidMinBSException(String msg) { super(msg);}

    public InvalidMinBSException(String msg, Throwable innerException) { super(msg, innerException);}
}