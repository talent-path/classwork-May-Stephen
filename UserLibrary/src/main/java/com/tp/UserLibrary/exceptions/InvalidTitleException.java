package com.tp.UserLibrary.exceptions;

public class InvalidTitleException extends Exception{
    public InvalidTitleException(String msg) {
        super(msg);
    }

    public InvalidTitleException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
