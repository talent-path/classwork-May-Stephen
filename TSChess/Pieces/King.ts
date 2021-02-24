import { Board } from "../Board";
import { Move } from "../Move";
import { Position } from "../Position";
import { ChessPiece } from "./ChessPiece";
import { Piece, PieceType } from "./Piece";

export class King extends ChessPiece {
    
    constructor( isWhite : boolean ){
        super( PieceType.King, isWhite );
    }

    generateMoves: (moveOn: Board, loc: Position) => Move[] = 
         (moveOn: Board, loc: Position)  => {
            this.inCheck( moveOn);
            let kingMoves : Move[]  = [];

            //we'll generate 4 "position" objects that represent different directions the king might move
            //then try those one at a time and add the results

            let kingDirections : Position[] = [];

            kingDirections.push( {row : 1, col: 1} );
            kingDirections.push( {row : 1, col: -1} );
            kingDirections.push( {row : -1, col: 1} );
            kingDirections.push( {row : -1, col: -1} );
            kingDirections.push( {row : 1, col: 0} );
            kingDirections.push( {row : -1, col: 0} );
            kingDirections.push( {row : 0, col: 1} );
            kingDirections.push( {row : 0, col: -1} );


            for( let direction of kingDirections ){
                let directionMoves : Move[] = King.slidePiece( moveOn, loc, direction, this.isWhite );
                kingMoves.push( ...directionMoves );
            }
            return kingMoves;
         };

         static slidePiece: (moveOn : Board, loc : Position, dir : Position, isWhite : boolean ) =>  Move[] = 
                    ( moveOn : Board, loc : Position, dir : Position, isWhite: boolean ) : Move[] => {

            let allMoves : Move[] = [];

            let currentLoc : Position = { row : loc.row + dir.row, col : loc.col + dir.col };

            if( King.isOnBoard( currentLoc ) && moveOn.pieceAt(currentLoc) === null ){
                allMoves.push( { from: loc, to: currentLoc  });
    
                currentLoc = { row: currentLoc.row + dir.row, col : currentLoc.col + dir.col };
            }

            if( King.isOnBoard( currentLoc ) && moveOn.pieceAt(currentLoc)){
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


    inCheck: (moveOn?: Board, currentSpot?: Position, endSpot?: Position, isWhite?: boolean) => boolean = 
        function(moveOn : Board, currentSpot : Position, endSpot : Position, isWhite : boolean) {
            let opposingPieces : Piece[] = [];
            for (const row of moveOn.allSquares){
                console.log(row);
                for(const piece of row) {
                    if (piece !== null && piece.isWhite != this.isWhite) {
                        opposingPieces.push(piece);
                    }
                }

            }
            return false;



            // let queensMoves : Move[] = new Queen(this.isWhite).generateMoves(moveOn, currentSpot);




            // let knightsMoves : Move[] = new Knight(this.isWhite).generateMoves(moveOn, currentSpot);

            // let allEnemyMoves = queensMoves.concat(knightsMoves);

            // return false;


    }

    
    
}