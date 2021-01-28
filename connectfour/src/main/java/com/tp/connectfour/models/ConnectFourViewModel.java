package com.tp.connectfour.models;

import java.util.List;

public class ConnectFourViewModel {

    Integer gameId;
    Integer[][] board;
    List<Integer> occupiedSpots;

    public Integer getGameId() {
        return gameId;
    }

    public void setGameId(Integer gameId) {
        this.gameId = gameId;
    }

    public Integer[][] getBoard() {
        return board;
    }

    public void setBoard(Integer[][] board){
        this.board = board;
    }

    public List<Integer> getOccupiedSpots(){
        return occupiedSpots;
    }

    public void setOccupiedSpots(List<Integer> occupiedSpots) {
        this.occupiedSpots = occupiedSpots;
    }
}
