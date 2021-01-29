package com.tp.UserLibrary.services;

import com.tp.UserLibrary.exceptions.*;
import com.tp.UserLibrary.models.LibraryBook;
import com.tp.UserLibrary.models.LibraryBookViewModel;
import com.tp.UserLibrary.persistence.LibraryDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;


import java.util.ArrayList;
import java.util.List;

@Component
public class LibraryService {


    @Autowired
    LibraryDao dao;


    public List<LibraryBookViewModel> getAllBooks() {
        List<LibraryBook> allBooks = dao.getAllBooks();
        List<LibraryBookViewModel> converted = new ArrayList<>();
        for (LibraryBook toConvert : allBooks) {
            converted.add(convertModel(toConvert));
        }
        return converted;
    }

    private LibraryBookViewModel convertModel(LibraryBook book) {
        LibraryBookViewModel toReturn = new LibraryBookViewModel();
        toReturn.setAuthors(book.getAuthors());
        toReturn.setBookId(book.getBookId());
        toReturn.setTitle(book.getTitle());
        toReturn.setYear(book.getYear());

        return toReturn;
    }

    public LibraryBookViewModel getBookById(Integer bookId){
    LibraryBook book = dao.getBookById(bookId);
    return convertModel(book);
    }

    public void deleteBook(Integer bookId) throws InvalidBookIdException, NullBookIdException {
        dao.deleteBook(bookId);
    }

    public LibraryBookViewModel addBook(Integer bookId, List<String> authors, String title, Integer year) throws InvalidBookIdException, InvalidPublicationYearException, InvalidTitleException, InvalidAuthorException {
        if ( bookId < 0) {
            throw new InvalidBookIdException("Invalid book ID.");
        }
        if ( authors == null) {
            throw new InvalidAuthorException("Invalid author(s).");
        }
        if (title == "") {
            throw new InvalidTitleException("Invalid title.");
        }
        if(year > 2021) {
            throw new InvalidPublicationYearException("Invalid publication year.");
        }
        LibraryBook book = dao.addBook(bookId, authors, title, year);
        return convertModel(book);
    }


    public LibraryBookViewModel getBookByAuthor(List<String> authors) throws InvalidAuthorException, NullAuthorsException {
        LibraryBook book = dao.getBookByAuthor(authors);
        return convertModel(book);
    }

    public LibraryBookViewModel getBookByTitle(String title) throws InvalidTitleException, NullTitleException {
        LibraryBook book = dao.getBookByTitle(title);
        return convertModel(book);
    }

    public LibraryBookViewModel getBookByYear(Integer year) throws InvalidPublicationYearException, NullYearException {
        LibraryBook book = dao.getBookByYear(year);
        return convertModel(book);
    }

//    public LibraryBookViewModel editTitle(String title) throws InvalidTitleException, NullTitleException {
//        LibraryBook book
//    }
}
