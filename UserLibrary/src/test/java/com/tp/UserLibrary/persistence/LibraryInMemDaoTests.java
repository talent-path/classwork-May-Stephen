package com.tp.UserLibrary.persistence;

import com.tp.UserLibrary.exceptions.*;
import com.tp.UserLibrary.models.LibraryBook;

import com.tp.UserLibrary.models.LibraryBookViewModel;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import static org.junit.jupiter.api.Assertions.*;


import java.util.Arrays;
import java.util.List;

@SpringBootTest
public class LibraryInMemDaoTests {
    @Autowired
    LibraryInMemDao dao;

    @BeforeEach
    public void setup() throws InvalidPublicationYearException, InvalidAuthorException, InvalidTitleException, InvalidBookIdException, NullBookIdException {
        List<LibraryBook> allBooks = dao.getAllBooks();
        for (LibraryBook toDelete : allBooks) {
            dao.deleteBook(toDelete.getBookId());
        }
        LibraryBook book = dao.addBook(1 , Arrays.asList(new String[]{"Frank Herbert"}), "Dune", 1965);
    }

    @Test
    public void testAddBookGoldenPath() {
        try {
            Integer bookId = 1;
            List<String> authors = Arrays.asList(new String[]{"George Orwell"});
            String title = "1984";
            Integer year = 1949;


            LibraryBook book = dao.addBook(bookId, authors, title, year);
        } catch (InvalidBookIdException | InvalidAuthorException | InvalidTitleException | InvalidPublicationYearException e) {
            fail();
        }
    }

    @Test
    public void getBookByNullIdTest() {
        try {
            LibraryBook book = dao.addBook(null, Arrays.asList(new String[]{"Frank Herbert"}), "Dune", 1965);
        } catch (InvalidTitleException | InvalidPublicationYearException | InvalidAuthorException ex) {
            fail();
        }
        catch (InvalidBookIdException ex){
            // do nothing
        }

    }

    @Test
    public void getBookByNullAuthorsTest() {
        try {
            LibraryBook book = dao.addBook(1, Arrays.asList(new String[]{null}), "Dune", 1965);
        } catch (InvalidTitleException | InvalidPublicationYearException | InvalidBookIdException ex) {
            fail();
        }
        catch (InvalidAuthorException ex){
            // do nothing
        }

    }

    @Test
    public void getBookByNullTitleTest() {
        try {
            LibraryBook book = dao.addBook(1, Arrays.asList(new String[]{"Frank Herbert"}), null, 1965);
        } catch (InvalidAuthorException | InvalidPublicationYearException | InvalidBookIdException ex) {
            fail();
        }
        catch (InvalidTitleException ex){
            // do nothing
        }

    }

    @Test
    public void getBookByNullYearTest() {
        try {
            LibraryBook book = dao.addBook(1, Arrays.asList(new String[]{"Frank Herbert"}), "Dune", null);
        } catch (InvalidAuthorException | InvalidTitleException | InvalidBookIdException ex) {
            fail();
        }
        catch (InvalidPublicationYearException ex){
            // do nothing
        }

    }

}

