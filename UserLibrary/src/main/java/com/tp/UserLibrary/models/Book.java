package com.tp.UserLibrary.models;

import java.util.List;

public class Book {
    private Integer bookId;
    private String title;
    private List<String> authors;
    private Integer year;


    public Book(Book that) {

        this.title = that.getTitle();
        this.authors = that.getAuthors();
        this.year = that.getYear();
    }

    public Book() {

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

    public void setAuthors(List<String> authors) {
    }

    public void setBookId(Integer bookId) {
    }

    public void setTitle(String title) {
    }

    public void setYear(Integer year) {
    }
}
