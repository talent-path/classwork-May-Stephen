package com.tp.UserLibrary.persistence;

import com.tp.UserLibrary.models.Book;

import java.util.List;

public interface LibraryDao {

    List<Book> getAllBooks();

    String deleteBook(Integer bookId);

    Book getBookById(Integer bookId);

    Book getBookByAuthor(List<String> authors);

    Book getBookByTitle(String title);

    Book getBookByYear(Integer year);

    Book addBook(Book partialBook);
}
