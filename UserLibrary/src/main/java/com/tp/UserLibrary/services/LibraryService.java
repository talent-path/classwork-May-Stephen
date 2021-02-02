package com.tp.UserLibrary.services;

import com.tp.UserLibrary.exceptions.*;
import com.tp.UserLibrary.models.Book;
import com.tp.UserLibrary.persistence.LibraryDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;


import java.util.ArrayList;
import java.util.List;

@Component
public class LibraryService {


    @Autowired
    LibraryDao dao;


    public List<Book> getAllBooks() {
        List<Book> allBooks = dao.getAllBooks();
        List<Book> copy = new ArrayList<>();
        for (Book toCopy : allBooks) {
            copy.add(toCopy);
        }
        return copy;
    }

//    private Book convertModel(Book book) {
//        Book toReturn = new Book();
//        toReturn.setAuthors(book.getAuthors());
//        toReturn.setBookId(book.getBookId());
//        toReturn.setTitle(book.getTitle());
//        toReturn.setYear(book.getYear());
//
//        return toReturn;
//    }

    public Book getBookById(Integer bookId){
    Book book = dao.getBookById(bookId);
    return book;
    }

    public void deleteBook(Integer bookId) throws InvalidBookIdException, NullBookIdException {
        dao.deleteBook(bookId);
    }

    public Book addBook(Book partialBook) {

        Book finishedBook = dao.addBook(partialBook);
        return finishedBook;
    }


    public Book getBookByAuthor(List<String> authors){
        Book book = dao.getBookByAuthor(authors);
        return book;
    }

    public Book getBookByTitle(String title){
        Book book = dao.getBookByTitle(title);
        return book;
    }

    public Book getBookByYear(Integer year){
        Book book = dao.getBookByYear(year);
        return book;
    }

//    public Book editTitle(String title) throws InvalidTitleException, NullTitleException {
//        LibraryBook book
//    }
}
