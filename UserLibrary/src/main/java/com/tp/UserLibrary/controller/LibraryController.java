package com.tp.UserLibrary.controller;

import com.tp.UserLibrary.models.LibraryBookViewModel;
import com.tp.UserLibrary.services.LibraryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;

import java.util.List;

public class LibraryController {
    @Autowired
    LibraryService service;



    @GetMapping("/book")
    public List<LibraryBookViewModel> getAllBooks() {
        LibraryBookViewModel book = null;
        try {
            book = service.getBookById(bookId);
        }

        return service.getAllBooks();
    }


    @GetMapping("/book/{bookId}")
    public LibraryBookViewModel getBookById(@PathVariable Integer bookId) {

    }

}


