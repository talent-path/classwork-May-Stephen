package com.tp.UserLibrary.controller;

import com.tp.UserLibrary.exceptions.*;
import com.tp.UserLibrary.models.LibraryBookViewModel;
import com.tp.UserLibrary.services.LibraryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class LibraryController {

    @Autowired
    LibraryService service;



    @GetMapping("/books")
    public List<LibraryBookViewModel> getAllBooks() {
       return service.getAllBooks();
    }


    @GetMapping("/id/{bookId}")
    public LibraryBookViewModel getBookById(@PathVariable Integer bookId) {
        return service.getBookById(bookId);
    }

    @PostMapping("/add")
    public ResponseEntity addBook(@RequestBody BookRequest request) {
        LibraryBookViewModel book = null;

        try{
            book = service.addBook(request.getBookId(), request.getAuthors(), request.getTitle(), request.getYear());
        }
        catch (InvalidBookIdException | InvalidAuthorException | InvalidTitleException | InvalidPublicationYearException ex) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(ex.getMessage());
        }

        return ResponseEntity.ok(book);
    }

    @GetMapping("/authors/{authors}")
    public LibraryBookViewModel getBookByAuthor(@PathVariable List<String> authors) throws InvalidAuthorException, NullAuthorsException {
        return service.getBookByAuthor(authors);
    }

    @GetMapping("/title/{title}")
    public LibraryBookViewModel getBookByTitle(@PathVariable String title) throws InvalidTitleException, NullTitleException {
        return service.getBookByTitle(title);
    }

    @GetMapping("/year/{year}")
    public LibraryBookViewModel getBookByYear(@PathVariable Integer year) throws InvalidPublicationYearException, NullYearException {
        return service.getBookByYear(year);
    }

    @DeleteMapping("/delete/{bookId}")
    public String deleteBook(@PathVariable Integer bookId) {
        try{
            service.deleteBook(bookId);
            return "Book " + bookId + " deleted successfully.";
        }
        catch(InvalidBookIdException | NullBookIdException ex) {
            return ex.getMessage();
        }
    }

//    @PutMapping("/edit/title/{title}")
//    public ResponseEntity editTitle(@RequestBody String request) throws InvalidTitleException, NullTitleException {
//        try{
//            service.editTitle(request);
//        }
//    }
}


