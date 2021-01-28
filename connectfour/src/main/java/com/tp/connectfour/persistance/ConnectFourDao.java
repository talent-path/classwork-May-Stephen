package com.tp.connectfour.persistance;

import com.tp.connectfour.exceptions.InvalidGameIdException;
import com.tp.connectfour.exceptions.NullBoardException;
import com.tp.connectfour.models.ConnectFourGame;

import java.util.List;

public interface ConnectFourDao {

    ConnectFourGame getGameById(Integer gameId) throws InvalidGameIdException;
    List<ConnectFourGame> getAllGames();
    void updateGame(ConnectFourGame game);
    int startGame(Integer[][] board) throws NullBoardException;
    void deleteGame(Integer gameId) throws InvalidGameIdException;

}
