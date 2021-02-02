package com.tp.UserLibrary.persistence;

import com.tp.UserLibrary.exceptions.*;
import com.tp.UserLibrary.models.Book;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class LibraryInMemDao implements LibraryDao {

    List<Book> allBooks = new ArrayList<>();

    @Override
    public List<Book> getAllBooks() {
        List<Book> copyList = new ArrayList<>();

        for(Book toCopy : allBooks) {
            copyList.add(new Book(toCopy));
        }

        return copyList;
    }


    @Override
    public Book getBookById(Integer bookId) {
        Book toReturn = null;

        for(Book toCheck : allBooks) {
            if(toCheck.getBookId().equals(bookId)) {
                toReturn = new Book(toCheck);
                break;
            }
        }
        return toReturn;
    }


    @Override
    public Book addBook(Book partialBook)  {
//        partialBook = new Book();
        int id = 0;

        for(Book toCheck : allBooks) {
            if(toCheck.getBookId() > id) {
                id = toCheck.getBookId();
            }
        }

        id++;


        Book copy = new Book(partialBook);
        copy.setBookId(id);
        allBooks.add(copy);
        return copy;
    }

    @Override
    public Book getBookByAuthor(List<String> authors){

        Book book = null;

        for(Book toCheck : allBooks) {
            if(toCheck.getAuthors().equals(authors)) {
                book = new Book(toCheck);
                break;
            }
        }
        return book;
    }



    @Override
    public Book getBookByTitle(String title){
        Book book = null;

        for(Book toCheck : allBooks) {
            if(toCheck.getTitle().equals(title)) {
                book = new Book(toCheck);
                break;
            }
        }
        return book;
    }
    @Override
    public Book getBookByYear(Integer year){
        Book book = null;

        for(Book toCheck : allBooks) {
            if(toCheck.getYear().equals(year)) {
                book = new Book(toCheck);
                break;
            }
        }
        return book;
    }

    @Override
    public void deleteBook(Integer bookId) throws InvalidBookIdException {
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
