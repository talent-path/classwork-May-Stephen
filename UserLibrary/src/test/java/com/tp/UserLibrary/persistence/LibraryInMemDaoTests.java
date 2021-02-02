package com.tp.UserLibrary.persistence;

import com.tp.UserLibrary.exceptions.*;
import com.tp.UserLibrary.models.Book;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import static org.junit.jupiter.api.Assertions.*;


import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

@SpringBootTest
public class LibraryInMemDaoTests {
    @Autowired
    LibraryInMemDao toTest;

    @BeforeEach


    public void reset() {
        toTest = new LibraryInMemDao();
    }


    @Test
    public void testAddBookGoldenPath() {
        Book partialBook = new Book();
        partialBook.setTitle("Test book");
        partialBook.setYear(2020);

        List<String> authors = new ArrayList<>();
        authors.add("Test author");
        partialBook.setAuthors(authors);




        //act
        Book returnedBook = toTest.addBook(partialBook);
        // check for save
        Book validationBook = toTest.getBookById(1);

        // assert book
        assertEquals(1, returnedBook.getBookId());
        assertEquals(1, returnedBook.getAuthors().size());
        assertEquals("Test author", returnedBook.getAuthors().get(0));
        assertEquals("Test book", returnedBook.getTitle());
        assertEquals(2020, returnedBook.getYear());

        assertEquals(1, validationBook.getBookId());
        assertEquals(1, validationBook.getAuthors().size());
        assertEquals("Test author", validationBook.getAuthors().get(0));
        assertEquals("Test book", validationBook.getTitle());
        assertEquals(2020, validationBook.getYear());

        Book secondBook = new Book();
        secondBook.setTitle("Second book");
        secondBook.setYear(2019);
        List<String> secondAuthors = new ArrayList<>();
        secondAuthors.add("Sec. Author 1");
        secondAuthors.add("Sec. Author 2");
        secondBook.setAuthors(secondAuthors);

        Book secondReturnedBook = toTest.addBook(secondBook);
        Book secondValidBook = toTest.getBookById(2);

        assertEquals(2, secondReturnedBook.getBookId());
        assertEquals(2, secondReturnedBook.getAuthors().size());
        assertEquals("Sec. Author 1", secondReturnedBook.getAuthors().get(0));
        assertEquals("Sec. Author 2", secondReturnedBook.getAuthors().get(1));
        assertEquals("Second Book", secondReturnedBook.getTitle());
        assertEquals(2019, secondReturnedBook.getYear());

        assertEquals(2, secondValidBook.getBookId());
        assertEquals(2, secondValidBook.getAuthors().size());
        assertEquals("Sec. Author 1", secondValidBook.getAuthors().get(0));
        assertEquals("Sec. Author 2", secondValidBook.getAuthors().get(1));
        assertEquals("Second Book", secondValidBook.getTitle());
        assertEquals(2019, secondValidBook.getYear());
    }

//    @Test
//    public void testAddBookNullBook() {
//        Book partialBook = new Book();
//        partialBook.setTitle("Test title");
//        partialBook.setYear(2020);
//        List<String> authors = new ArrayList<>();
//        authors.add("Test author");
//        partialBook.setAuthors(authors);
//
//        assertThrows(InvalidBookException.class, () -> toTest.addBook(null));
//    }

    @Test
    public void testAddBookNullAuthorList() {
        Book partialBook = new Book();
        partialBook.setTitle("Test Title");
        partialBook.setYear(2020);

        partialBook.setAuthors(null);

        assertThrows(InvalidAuthorException.class, () -> toTest.addBook(partialBook));
    }

    @Test
    public void testAddBookNullYear() {
        Book partialBook = new Book();
        partialBook.setTitle("Test Title");
        partialBook.setYear(null);
        List<String> authors = new ArrayList<>();
        authors.add("Test author");
        partialBook.setAuthors(authors);

        assertThrows(InvalidYearException.class, () -> toTest.addBook(partialBook));
    }

    @Test
    public void testAddBookNullTitle() {
        Book partialBook = new Book();
        partialBook.setTitle(null);
        partialBook.setYear(2020);
        List<String> authors = new ArrayList<>();
        authors.add("Test author");
        partialBook.setAuthors(authors);

        assertThrows(InvalidTitleException.class, () -> toTest.addBook(partialBook));
    }

    @Test
    public void testAddBookInvalidTitle() {
        Book partialBook = new Book();
        partialBook.setTitle(" ");
        partialBook.setYear(2020);
        List<String> authors = new ArrayList<>();
        authors.add("Test author");
        partialBook.setAuthors(authors);

        assertThrows(InvalidTitleException.class, () -> toTest.addBook(partialBook));
    }

    @Test
    public void testGetAllBooksCorrectId() {
        Book partialBook = new Book();
        partialBook.setTitle("Test title");
        partialBook.setYear(2020);
        List<String> authors = new ArrayList<>();
        authors.add("Test author");
        partialBook.setAuthors(authors);

        assertThrows(InvalidTitleException.class, () -> toTest.getAllBooks(partialBook));
    }
}

