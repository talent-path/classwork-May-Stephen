package com.tp.UserLibrary.services;

import com.tp.UserLibrary.exceptions.*;
import com.tp.UserLibrary.models.LibraryBook;
import com.tp.UserLibrary.models.LibraryBookViewModel;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;

import static org.junit.jupiter.api.Assertions.fail;

@SpringBootTest
public class LibraryServicesTests {

    @Autowired
    LibraryService service;

    @BeforeEach
    public void setup() throws InvalidBookIdException, InvalidTitleException, InvalidPublicationYearException, InvalidAuthorException, NullBookIdException {
        List<LibraryBookViewModel> allBooks = service.getAllBooks();
        for( LibraryBookViewModel toDelete : allBooks){
            service.deleteBook( toDelete.getBookId());
        }
        //LibraryBookViewModel book = service.addBook(1 , Arrays.asList(new String[]{"Frank Herbert"}), "Dune", 1965);
        //LibraryBookViewModel book2 = service.addBook(2 , Arrays.asList(new String[]{"Some guy not born yet"}), "Some Futuristic Book", 2050);
    }

    //Test getBookId
//    @Test
//    public void getBookIdTest() {
//
//    }

    //test add Book methods

    @Test
    public void getBookByInvalidTitleTest() {
        try {
            LibraryBookViewModel book = service.getBookByTitle("");
        }
        catch (InvalidTitleException | NullTitleException ex){
            // do nothing
        }

    }

    @Test
    public void getBookByInvalidYearTest() {
        try {
            LibraryBookViewModel book = service.getBookByYear(2050);
            fail();
        }
        catch (NullYearException | InvalidPublicationYearException ex){
            // do nothing
        }

    }




}
