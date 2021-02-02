package com.tp.UserLibrary.services;

import com.tp.UserLibrary.exceptions.*;
import com.tp.UserLibrary.models.Book;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.List;

import static org.junit.jupiter.api.Assertions.fail;

@SpringBootTest
public class LibraryServicesTests {

    @Autowired
    LibraryService service;

    @BeforeEach
    public void setup() throws InvalidBookIdException, NullBookIdException {
        List<Book> allBooks = service.getAllBooks();
        for (Book toDelete : allBooks) {
            service.deleteBook(toDelete.getBookId());
        }
        //Book book = service.addBook(1 , Arrays.asList(new String[]{"Frank Herbert"}), "Dune", 1965);
        //Book book2 = service.addBook(2 , Arrays.asList(new String[]{"Some guy not born yet"}), "Some Futuristic Book", 2050);
    }
}
    //Test getBookId
//    @Test
//    public void getBookIdTest() {
//
//    }

    //test add Book methods

