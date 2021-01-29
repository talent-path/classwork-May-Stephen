package com.tp.UserLibrary.models;

import java.util.List;

public class LibraryBook {
    private Integer bookId;
    private String title;
    private List<String> authors;
    private Integer year;


    public LibraryBook(Integer bookId, String title, List<String> authors, Integer year) {
        this.bookId = bookId;
        this.title = title;
        this.authors = authors;
        this.year = year;
    }


    public LibraryBook(LibraryBook that) {
        this.bookId = that.bookId;
        this.title = that.title;
        this.authors = that.authors;
        this.year = that.year;
    }

    public Integer getBookId() {
        return bookId;
    }

    public String getTitle() {
        return title;
    }

    public List<String> getAuthors() {
        return authors;
    }

    public Integer getYear() {
        return year;
    }
}
