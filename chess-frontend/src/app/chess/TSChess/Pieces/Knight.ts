import { Board } from "../Board";
import { Move } from "../Move";
import { Position } from "../Position";
import { ChessPiece } from "./ChessPiece";
import { PieceType } from "./Piece";

export class Knight extends ChessPiece {

    constructor( isWhite : boolean ){
        super( PieceType.Knight, isWhite );
    }

    generateMoves: (moveOn: Board, loc: Position) => Move[] = 
         (moveOn: Board, loc: Position)  => {

            let knightMoves : Move[]  = [];

            //we'll generate 4 "position" objects that represent different directions the knight might move
            //then try those one at a time and add the results

            let knightDirections : Position[] = [];

            knightDirections.push( {row : 2, col: 1} );
            knightDirections.push( {row : 2, col: -1} );
            knightDirections.push( {row : -2, col: 1} );
            knightDirections.push( {row : -2, col: -1} );
            knightDirections.push( {row : -1, col: 2} );
            knightDirections.push( {row : -1, col: -2} );
            knightDirections.push( {row : 1, col: 2} );
            knightDirections.push( {row : 1, col: -2} );


            for( let direction of knightDirections ){
                let directionMoves : Move[] = Knight.slidePiece( moveOn, loc, direction, this.isWhite );
                knightMoves.push( ...directionMoves );
            }

            return knightMoves;
         };

         static slidePiece: (moveOn : Board, loc : Position, dir : Position, isWhite : boolean ) =>  Move[] = 
                    ( moveOn : Board, loc : Position, dir : Position, isWhite: boolean ) : Move[] => {

            let allMoves : Move[] = [];

            let currentLoc : Position = { row : loc.row + dir.row, col : loc.col + dir.col };

            if( Knight.isOnBoard( currentLoc ) && moveOn.pieceAt(currentLoc) === null ){
                allMoves.push( { from: loc, to: currentLoc  });
    
                currentLoc = { row: currentLoc.row + dir.row, col : currentLoc.col + dir.col };
            }

            if( Knight.isOnBoard( currentLoc ) && moveOn.pieceAt(currentLoc)){
                console.log(currentLoc);
                if( moveOn.pieceAt(currentLoc).isWhite != isWhite  ){
                    allMoves.push( {from: loc, to: currentLoc});
                }
            }
            
            return allMoves;
        }

    static isOnBoard( loc : Position ) : boolean {
        return loc.col >= 0 && loc.col < 8 && loc.row >= 0 && loc.row < 8;
    }
}