
import { Component, OnInit } from '@angular/core';
import { Board, ChessBoard } from '../chess/TSChess/Board';
import { Move } from '../chess/TSChess/Move';
import { PieceType, Piece } from '../chess/TSChess/Pieces/Piece';
import { Position } from '../chess/TSChess/Position';

@Component({
  selector: 'app-chess-board',
  templateUrl: './chess-board.component.html',
  styleUrls: ['./chess-board.component.css']
})
export class ChessBoardComponent implements OnInit {
  firstSquareSelected : Position = null;
  secondSquareSelected : Position = null;
  board : Board = new ChessBoard();
  constructor() { }


  ngOnInit(): void {
  }

  onSquareClicked(pos : Position) : void{
    console.log(pos);
    let pieceAtPos : Piece = this.board.pieceAt(pos);
      if(this.firstSquareSelected == null) {
        if (pieceAtPos != null) {
            if (this.board.isWhiteTurn == pieceAtPos.isWhite ) {
                this.firstSquareSelected = pos;
            }
        }  
      }
      else {
        let possibleMove : Move = this.board.generateMoves().find(
            (move : Move) => {
                return move.from.col == this.firstSquareSelected.col && move.from.row == this.firstSquareSelected.row
                && move.to.row == pos.row && move.to.col == pos.col;
            }

            



        );
        if (possibleMove) {
          this.board = this.board.makeMove(possibleMove);
          this.firstSquareSelected = null;
        }
      }
  }

}
