package com.tp.UserLibrary.persistence;

import com.tp.UserLibrary.exceptions.*;
import com.tp.UserLibrary.models.LibraryBook;

import java.util.List;

public interface LibraryDao {

    List<LibraryBook> getAllBooks();

    void deleteBook(Integer bookId) throws InvalidBookIdException, NullBookIdException;

    LibraryBook getBookById(Integer bookId);

    LibraryBook addBook(Integer bookId, List<String> authors, String title, Integer year) throws InvalidBookIdException, InvalidAuthorException, InvalidTitleException, InvalidPublicationYearException;

    LibraryBook getBookByAuthor(List<String> authors) throws InvalidAuthorException, NullAuthorsException;

    LibraryBook getBookByTitle(String title) throws InvalidTitleException, NullTitleException;

    LibraryBook getBookByYear(Integer year) throws InvalidPublicationYearException, NullYearException;
}
