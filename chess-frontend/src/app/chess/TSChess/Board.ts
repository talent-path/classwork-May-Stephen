import { Move } from "./Move";
import { Bishop } from "./Pieces/Bishop";
import { BlackPawn } from "./Pieces/BlackPawn";
import { ChessPiece } from "./Pieces/ChessPiece";
import { King } from "./Pieces/King";
import { Knight } from "./Pieces/Knight";
import { Piece, PieceType } from "./Pieces/Piece"
import { Queen } from "./Pieces/Queen";
import { Rook } from "./Pieces/Rook";
import { WhitePawn } from "./Pieces/WhitePawn";
import { Position } from "./Position"

export interface Board {

    allSquares: Piece[][];

    isWhiteTurn: boolean;
    // wKingSideCastle : boolean;
    // wQueenSideCastle: boolean;
    // bKingSideCastle : boolean;
    // bQueenSideCastle: boolean;

    // fiftyMoveCount : number;
    // enPassantCaptureLoc : Position;

    makeMove: (this: Board, toMake: Move) => Board;
    pieceAt: (loc: Position) => Piece;
    generateMoves: () => Move[];
}


export class ChessBoard implements Board {

    //TODO: capture this in the copy constructor at some point...
    // fiftyMoveCount : number;
    // enPassantCaptureLoc : Position;
    isWhiteTurn: boolean = true;
    // wKingSideCastle : boolean;
    // wQueenSideCastle: boolean;
    // bKingSideCastle : boolean;
    // bQueenSideCastle: boolean;
    allSquares: Piece[][];

    pieceAt(loc: Position): Piece {

        return this.allSquares[loc.row][loc.col];
    }


    constructor(copyFrom?: ChessBoard) {
        if (copyFrom) {
            this.buildFrom(copyFrom);
        }
        else {
            this.allSquares = [];
            for (let row = 0; row < 8; row++) {
                this.allSquares[row] = [];
                for (let col = 0; col < 8; col++) {

                    if( row === 1 || row === 6 ){
                        this.allSquares[row][col] =  row === 1 ? new WhitePawn() : new BlackPawn();
                    }

                    if ((row === 0 || row === 7) && (col === 0 || col === 7)) {
                        this.allSquares[row][col] = new Rook(row === 0);
                    }

                    if ((row === 0 || row === 7) && (col === 1 || col === 6)) {
                        this.allSquares[row][col] = new Knight(row === 0);
                    }

                    if ((row === 0 || row === 7) && (col === 2 || col === 5)) {
                        this.allSquares[row][col] = new Bishop(row === 0);
                    }

                    if (col === 3 && (row === 0 || row === 7)) {
                        this.allSquares[row][col] = new Queen(row === 0);
                    }

                    if (col === 4 && (row === 0 || row === 7)) {
                        this.allSquares[row][col] = new King(row === 0);
                    }

                    if (!this.allSquares[row][col]) {
                        this.allSquares[row][col] = null;
                    }

                }
            }
        }
    }

    buildFrom(toCopy: Board) {


        this.allSquares = [];
        for (let i = 0; i < toCopy.allSquares.length; i++) {
            this.allSquares.push([...toCopy.allSquares[i]]);
        }
    }


    makeMove: (toMake: Move) => Board = toMake => {


        let nextBoard: ChessBoard = new ChessBoard(this);


        let oldPiece: Piece = nextBoard.allSquares[toMake.from.row][toMake.from.col];

        nextBoard.allSquares[toMake.from.row][toMake.from.col] = null;
        nextBoard.allSquares[toMake.to.row][toMake.to.col] = oldPiece;
        nextBoard.isWhiteTurn = !this.isWhiteTurn;


        //console.log(oldPiece);
        return nextBoard;
    }

    generateMoves(): Move[] {

        let allMoves: Move[] = [];

        for (let row = 0; row < 8; row++) {
            for (let col = 0; col < 8; col++) {
                if (this.allSquares[row][col]) {
                    //console.log(this.allSquares[row][col]);
                    allMoves.push(...this.allSquares[row][col].generateMoves(this, { row, col }))
                }
            }
        }

        return allMoves;
    }

}


let testBoard: Board = new ChessBoard();

//console.log( testBoard );

testBoard = testBoard.makeMove({ from: { row: 0, col: 0 }, to: { row: 4, col: 4 } });
//console.log( testBoard.generateMoves() );