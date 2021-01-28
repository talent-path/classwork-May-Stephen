package com.tp.connectfour.services;

import com.tp.connectfour.exceptions.InvalidGameIdException;
import com.tp.connectfour.exceptions.NullBoardException;
import com.tp.connectfour.models.ConnectFourGame;
import com.tp.connectfour.persistance.ConnectFourInMemDao;
import org.junit.jupiter.api.BeforeEach;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.List;

import static org.junit.jupiter.api.Assertions.*;


@SpringBootTest
public class ConnectFourInMemDaoTests {
    @Autowired
    ConnectFourInMemDao dao;

    @BeforeEach
    public void setup() throws InvalidGameIdException, NullBoardException {
        List<ConnectFourGame> allGames = dao.getAllGames();
        for (ConnectFourGame toDelete : allGames) {
            dao.deleteGame(toDelete.getGameId());

        }

        dao.startGame(new Integer[6][7]);
    }

    // getGameById
    // test for null Id, and invalid Id

    //updateGame
    // test for null game object,

    // startGame
    // test Golden Path, for null board

    // deleteGame
    // test for null id, invalid id
}