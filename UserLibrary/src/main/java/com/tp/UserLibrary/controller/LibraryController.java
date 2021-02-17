package com.tp.UserLibrary.controller;

import com.tp.UserLibrary.exceptions.*;
import com.tp.UserLibrary.models.Book;

import com.tp.UserLibrary.services.LibraryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class LibraryController {

    @Autowired
    LibraryService service;



    @GetMapping("/books")
    public List<Book> getAllBooks() {
       return service.getAllBooks();
    }


    @GetMapping("/id/{bookId}")
    public Book getBookById(@PathVariable Integer bookId) {
        return service.getBookById(bookId);
    }

    @PostMapping("/add")
    public ResponseEntity addBook(@RequestBody Book partialBook) {
        Book finishedBook = service.addBook(partialBook);

        return ResponseEntity.ok(finishedBook);
    }

    @GetMapping("/authors/{authors}")
    public Book getBookByAuthor(@PathVariable List<String> authors) throws InvalidAuthorException, NullAuthorsException {
        return service.getBookByAuthor(authors);
    }

    @GetMapping("/title/{title}")
    public Book getBookByTitle(@PathVariable String title) throws InvalidTitleException, NullTitleException {
        return service.getBookByTitle(title);
    }

    @GetMapping("/year/{year}")
    public Book getBookByYear(@PathVariable Integer year) throws InvalidYearException, NullYearException {
        return service.getBookByYear(year);
    }

    @DeleteMapping("/delete/{bookId}")
    public String deleteBook(@PathVariable Integer bookId) {

            service.deleteBook(bookId);
            return "Book " + bookId + " deleted successfully.";
        }
    }

//    @PutMapping("/edit/title")
//    public ResponseEntity editTitle(@RequestBody String request) {
//        try{
//            service.editTitle(request);
//
//        }
//    }



