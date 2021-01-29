package com.tp.UserLibrary.persistence;

import com.tp.UserLibrary.exceptions.*;
import com.tp.UserLibrary.models.LibraryBook;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class LibraryInMemDao implements LibraryDao {

    List<LibraryBook> allBooks = new ArrayList<>();

    @Override
    public List<LibraryBook> getAllBooks() {
        List<LibraryBook> copyList = new ArrayList<>();

        for(LibraryBook toCopy : allBooks) {
            copyList.add(new LibraryBook(toCopy));
        }

        return copyList;
    }


    @Override
    public LibraryBook getBookById(Integer bookId) {
        LibraryBook book = null;

        for(LibraryBook toCheck : allBooks) {
            if(toCheck.getBookId().equals(bookId)) {
                book = new LibraryBook(toCheck);
                break;
            }
        }
        return book;
    }


    @Override
    public LibraryBook addBook(Integer bookId, List<String> authors, String title, Integer year) throws InvalidBookIdException, InvalidAuthorException, InvalidTitleException, InvalidPublicationYearException {
//        if (authors == null) {
//            throw new InvalidAuthorException("Invalid author(s) provided.");
//        }
//        if ( title == null) {
//            throw new InvalidTitleException("Invalid book title provided.");
//        }
//        if (year == null) {
//            throw new InvalidPublicationYearException("Invalid publication year provided.");
//        }
//        if (bookId == null) {
//            throw new InvalidBookIdException("Invalid book ID provided.");
//        }
        int id = 0;

        for(LibraryBook toCheck : allBooks) {
            if(toCheck.getBookId() > id) {
                id = toCheck.getBookId();
            }
        }

        id++;
        LibraryBook toAdd = new LibraryBook(id, title, authors, year);

        allBooks.add(toAdd);

        return toAdd;
    }

    @Override
    public LibraryBook getBookByAuthor(List<String> authors) throws InvalidAuthorException, NullAuthorsException {

        LibraryBook book = null;

        for(LibraryBook toCheck : allBooks) {
            if(toCheck.getAuthors().equals(authors)) {
                book = new LibraryBook(toCheck);
                break;
            }
        }
        return book;
    }



    @Override
    public LibraryBook getBookByTitle(String title) throws InvalidTitleException, NullTitleException {
        LibraryBook book = null;

        for(LibraryBook toCheck : allBooks) {
            if(toCheck.getTitle().equals(title)) {
                book = new LibraryBook(toCheck);
                break;
            }
        }
        return book;
    }
    @Override
    public LibraryBook getBookByYear(Integer year) throws InvalidPublicationYearException, NullYearException {
        LibraryBook book = null;

        for(LibraryBook toCheck : allBooks) {
            if(toCheck.getYear().equals(year)) {
                book = new LibraryBook(toCheck);
                break;
            }
        }
        return book;
    }

    @Override
    public void deleteBook(Integer bookId) throws InvalidBookIdException, NullBookIdException {
        int removeIndex = -1;

        for( int i = 0; i < allBooks.size(); i++) {
            if(allBooks.get(i).getBookId().equals(bookId)) {
                removeIndex = i;
                break;
            }
        }

        if(removeIndex != -1){
            allBooks.remove(removeIndex);
        } else {
            throw new InvalidBookIdException("Could not find book with ID " + bookId);
        }
    }


}
