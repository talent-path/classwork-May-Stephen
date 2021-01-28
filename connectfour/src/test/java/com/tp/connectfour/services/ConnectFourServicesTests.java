package com.tp.connectfour.services;

import com.tp.connectfour.exceptions.InvalidGameIdException;
import com.tp.connectfour.exceptions.NullBoardException;
import com.tp.connectfour.exceptions.NullChoiceException;
import com.tp.connectfour.exceptions.InvalidChoiceException;
import com.tp.connectfour.models.ConnectFourViewModel;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.List;

import static org.junit.jupiter.api.Assertions.*;


@SpringBootTest
public class ConnectFourServicesTests {
    @Autowired
    ConnectFourService service;

    @BeforeEach
    public void setup() throws InvalidGameIdException {
        List<ConnectFourViewModel> allGames = service.getAllGames();
        for( ConnectFourViewModel toDelete : allGames ){
            service.deleteGame( toDelete.getGameId() );

        }


    }

    // getGameId
    // test for null id, test for invalid id


    //startGame
    // test golden path (all parameters)
    @Test
    public void startGameTestGoldenPath() {
        try{
            ConnectFourViewModel game = service.startGame();
            assertEquals(1, game.getGameId());
            for(int row = 0; row < game.getBoard().length; row++) {
                for( int col = 0 ; col < game.getBoard()[row].length; col++){
                    assertEquals(0, game.getBoard()[row][col]);
                }
            }
            assertTrue(game.getOccupiedSpots().isEmpty());
        }
        catch(NullBoardException | InvalidGameIdException ex) {
            fail();
        }

    }

    // makeChoice
    @Test
    public void makeChoiceTestNullChoice() {
        try {
            ConnectFourViewModel game = service.startGame();
            ConnectFourViewModel gameAfterChoice = service.makeChoice(1, null);
            fail();
        }
        catch (InvalidGameIdException | InvalidChoiceException | NullBoardException ex) {
            fail();
        }
        catch (NullChoiceException ex) {
            // do nothing
        }
    }

    @Test
    public void makeChoiceTestInvalidChoice() {
        try {
            ConnectFourViewModel game = service.startGame();
            ConnectFourViewModel gameAfterChoice = service.makeChoice(1, 8);
            fail();
        }
        catch (InvalidGameIdException | NullBoardException | NullChoiceException ex) {
            fail();
        }
        catch (InvalidChoiceException ex) {
            // do nothing
        }
    }

    @Test
    public void makeChoiceTestInvalidGameId() {
        try {
            ConnectFourViewModel game = service.startGame();
            ConnectFourViewModel gameAfterChoice = service.makeChoice(10, 0);
            fail();
        }
        catch (InvalidChoiceException | NullBoardException | NullChoiceException ex) {
            fail();
        }
        catch (InvalidGameIdException ex) {
            // do nothing
        }
    }

    // deleteGame
    // test for null game id, invalid id

    // convertModel
    // test for null game



}
