package com.tp.UserLibrary.controller;

import java.util.List;

public class BookRequest {

    private Integer bookId;
    private List<String> authors;
    private Integer year;
    private String title;

    public Integer getBookId() {
        return bookId;
    }

    public void setBookId(Integer bookId) {
        this.bookId = bookId;
    }

    public List<String> getAuthors() {
        return authors;
    }

    public void setAuthors(List<String> authors) {
        this.authors = authors;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public Integer getYear(){
        return year;
    }

    public void setYear(Integer year) {
        this.year = year;
    }
}
