package com.tp.UserLibrary.exceptions;

public class InvalidBookIdException extends Exception{
    public InvalidBookIdException(String msg) {
        super(msg);
    }
    public InvalidBookIdException(String msg, Throwable innerException) {
        super(msg, innerException);
    }

}
