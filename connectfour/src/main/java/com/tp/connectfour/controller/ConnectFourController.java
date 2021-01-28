package com.tp.connectfour.controller;

import com.tp.connectfour.exceptions.*;
import com.tp.connectfour.models.ConnectFourGame;
import com.tp.connectfour.models.ConnectFourViewModel;
import com.tp.connectfour.services.ConnectFourService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class ConnectFourController {

    //TODO: Autowire Service
    @Autowired
    ConnectFourService service;

    @GetMapping("/game")
    public List<ConnectFourViewModel> getAllGames() {
            return service.getAllGames();
    }

    @GetMapping("/game/{gameId}")
    public ConnectFourViewModel getGameById(@PathVariable Integer gameId) {
        ConnectFourViewModel game = null;
        try {
            game = service.getGameById(gameId);
        }
        catch (InvalidGameIdException ex) {
            ex.getMessage();
        }
        return game;
    }

    @PostMapping("/choice")
    public ResponseEntity chooseSpot(@RequestBody ChoiceRequest request) {
        //TODO fill with try/catch stuff
        ConnectFourViewModel toReturn = null;

        try{
            toReturn = service.makeChoice(request.getGameId(), request.getChoice());
        } catch (NullChoiceException | InvalidChoiceException | InvalidGameIdException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @PostMapping("/begin")
    public ConnectFourViewModel startGame() throws NullBoardException {
        ConnectFourViewModel game = null;
        try {
            game = service.startGame();
        } catch (NullBoardException | InvalidGameIdException ex) {
            ex.getMessage();
        }
        return game;
    }

    @DeleteMapping("/delete/{gameId}")
    public String deleteGame(@PathVariable Integer gameId) {
        try{
            service.deleteGame(gameId);
            return "Game " + gameId + " deleted successfully.";
        }
        catch( InvalidGameIdException ex) {
            return ex.getMessage();
        }
    }

}
