package com.tp.UserLibrary.exceptions;

public class InvalidYearException extends Exception {
    public InvalidYearException(String msg) {
        super(msg);
    }

    public InvalidYearException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
