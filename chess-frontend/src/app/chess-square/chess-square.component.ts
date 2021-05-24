import { Component, Input, OnInit } from '@angular/core';
import { Bishop } from '../chess/TSChess/Pieces/Bishop';
import { Piece, PieceType } from '../chess/TSChess/Pieces/Piece';
import { Rook } from '../chess/TSChess/Pieces/Rook';
import { Output, EventEmitter } from '@angular/core';
import { Position } from '../chess/TSChess/Position';


@Component({
  selector: 'app-chess-square',
  templateUrl: './chess-square.component.html',
  styleUrls: ['./chess-square.component.css']

})



export class ChessSquareComponent implements OnInit {

  @Output()squareClickedEvent : EventEmitter<Position>  = new EventEmitter<Position>();


  @Input()squarePiece: Piece = new Bishop(true);
  imageSrc : string = "./assets/";
  @Input()row : number = 0;
  @Input()col : number = 0;
  isLightSquare : boolean = true;

  constructor() {
      
   }

  ngOnInit(): void {
    if(this.squarePiece == null){
      this.imageSrc = " ";
    }
    else {
    this.imageSrc += this.squarePiece.isWhite ? "w" : "b";
      switch(this.squarePiece.kind) {
        case PieceType.Bishop: this.imageSrc += "B"; break;
        case PieceType.Rook: this.imageSrc += "R"; break;
        case PieceType.Knight: this.imageSrc += "N"; break;
        case PieceType.Queen: this.imageSrc += "Q"; break;
        case PieceType.King: this.imageSrc += "K"; break;
        case PieceType.Pawn: this.imageSrc += "P"; break;
          

      }
      this.imageSrc += ".png";
    }
      this.isLightSquare = ((this.row + this.col) % 2 === 0);
      
  }


  squareClicked() : void {
    this.squareClickedEvent.emit(
      {
       row : this.row,
       col : this.col
      })
  }
}
