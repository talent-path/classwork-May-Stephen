package com.tp.DiabetesTracker.exceptions;

public class InvalidMaxBSException extends Exception{

    public InvalidMaxBSException(String msg) {super(msg);}

    public InvalidMaxBSException(String msg, Throwable innerException) {super( msg, innerException);}
}