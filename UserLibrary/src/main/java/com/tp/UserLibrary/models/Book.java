package com.tp.UserLibrary.models;

import java.util.ArrayList;
import java.util.List;

public class Book {
    Integer bookId;
    String title;
    List<String> authors;
    Integer year;

    public Book() {

    }

    public Book(Book that) {
        this.bookId = that.bookId;
        this.title = that.title;

        this.year = that.year;

        this.authors = new ArrayList<>();
        this.authors.addAll(that.authors);
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
        this.authors = authors;
    }

    public void setBookId(Integer bookId) {
        this.bookId = bookId;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setYear(Integer year) {
        this.year = year;
    }
}
