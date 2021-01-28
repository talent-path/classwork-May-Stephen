package com.tp.connectfour.services;

import com.tp.connectfour.exceptions.*;
import com.tp.connectfour.models.ConnectFourGame;
import com.tp.connectfour.models.ConnectFourViewModel;
import com.tp.connectfour.persistance.ConnectFourDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class ConnectFourService {

    @Autowired
    ConnectFourDao dao;

    public List<ConnectFourViewModel> getAllGames() {
        List<ConnectFourGame> allGames = dao.getAllGames();
        List<ConnectFourViewModel> converted = new ArrayList<>();
        for( ConnectFourGame toConvert : allGames) {
            converted.add(convertModel(toConvert));
        }
        return converted;

    }

    public ConnectFourViewModel getGameById(Integer gameId) throws InvalidGameIdException {
        ConnectFourGame game = null;
        try {
            game = dao.getGameById(gameId);
        }
        catch (InvalidGameIdException ex) {
            ex.getMessage();
        }
        return convertModel(game);
    }

    public ConnectFourViewModel startGame() throws NullBoardException, InvalidGameIdException {
            Integer[][] newBoard = new Integer[6][7];
            int newGameId = dao.startGame(newBoard);

            return this.getGameById(newGameId);

    }

    public ConnectFourViewModel makeChoice(Integer gameId, Integer choice)
            throws NullChoiceException, InvalidChoiceException, InvalidGameIdException {
        if(choice == null)
            throw new NullChoiceException("Null choice exception.");
        if(choice < 0 || choice > 6)
            throw new InvalidChoiceException("Not a valid column choice.");
        if(gameId == null)
            throw new InvalidGameIdException("Invalid game id.");



        ConnectFourGame game = dao.getGameById(gameId);
        if(game == null)
            throw new InvalidGameIdException("Can not find game with id " + gameId);
        //If user makes valid choice
        //Piece goes down until it reaches another piece OR row 5 (max row)
        // -1: player 1 | 0: empty | 1: player 2
        for(int row = 0; row < 6; row++) {
            if(game.getBoard()[row][choice] != 0 || row == 5) {
                //TODO figure out determining which player is playing
                if (row == 5 && game.getBoard()[row][choice] == 0) {
                    game.getBoard()[row][choice] = 1;
                } else {
                    game.getBoard()[row - 1][choice] = 1;
                }
                break;

            }

            else  if(game.getBoard()[row][choice] == 0) {//If the spot is empty
                    //Check next row to see if it is also empty
                    //Else place checker
                    continue;
                }
            }



        //Add choice to occupiedSpots list
        game.getOccupiedSpots().add(choice);
        //Update allGames list with current game state
        //game.getBoard()[0][6] = 1;
        dao.updateGame(game);
        return convertModel(game);

    }

    public void deleteGame(Integer gameId) throws InvalidGameIdException {
        dao.deleteGame(gameId);
    }

    private ConnectFourViewModel convertModel(ConnectFourGame game) {
        ConnectFourViewModel toReturn = new ConnectFourViewModel();
        toReturn.setBoard(game.getBoard());
        toReturn.setGameId(game.getGameId());
        toReturn.setOccupiedSpots(game.getOccupiedSpots());
        return toReturn;
    }
}
