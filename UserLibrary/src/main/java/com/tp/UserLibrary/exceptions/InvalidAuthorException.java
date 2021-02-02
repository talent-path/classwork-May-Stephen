package com.tp.UserLibrary.exceptions;

public class InvalidAuthorException extends Exception{
    public InvalidAuthorException(String msg) {
        super(msg);
    }

    public InvalidAuthorException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
