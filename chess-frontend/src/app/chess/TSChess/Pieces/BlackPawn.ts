import { Board } from "../Board";
import { Move } from "../Move";
import { Position } from "../Position";
import { ChessPiece } from "./ChessPiece";
import { PieceType } from "./Piece";

export class BlackPawn extends ChessPiece {
    turnCount : number = 0;
    
    constructor(){
        super( PieceType.Pawn, false);
    }

    generateMoves: (moveOn: Board, loc: Position) => Move[] = 
         (moveOn: Board, loc: Position)  => {

            let PawnMoves : Move[]  = [];

            //we'll generate 4 "position" objects that represent different directions the pawn might move
            //then try those one at a time and add the results

            let pawnDirections : Position[] = [];

            let leftDiag : Position = {row : loc.row -1, col: loc.col + 1};
            let rightDiag : Position = {row : loc.row -1, col: loc.col -1};
            
            pawnDirections.push( {row : -1, col: 0} );
            if(this.turnCount === 0) {
            pawnDirections.push( {row : -2, col: 0} );
            }
            
            if(BlackPawn.isOnBoard(leftDiag) && moveOn.pieceAt(leftDiag) !== null) {
                if( moveOn.pieceAt(leftDiag).isWhite != this.isWhite) {
                    pawnDirections.push( {row : -1, col: 1} );
                }

            }
            
            if(BlackPawn.isOnBoard(rightDiag) && moveOn.pieceAt(rightDiag) !== null) {
                if(moveOn.pieceAt(rightDiag).isWhite != this.isWhite) {
                    pawnDirections.push( {row : -1, col: -1} );
                }
            }
            
            

            for( let direction of pawnDirections ){
                let directionMoves : Move[] = BlackPawn.slidePiece( moveOn, loc, direction, this.isWhite );
                PawnMoves.push( ...directionMoves );
            }

            return PawnMoves;
         };

         static slidePiece: (moveOn : Board, loc : Position, dir : Position, isWhite : boolean ) =>  Move[] = 
                    ( moveOn : Board, loc : Position, dir : Position, isWhite: boolean ) : Move[] => {

            let allMoves : Move[] = [];

            let currentLoc : Position = { row : loc.row + dir.row, col : loc.col + dir.col };

            if( BlackPawn.isOnBoard( currentLoc ) && moveOn.pieceAt(currentLoc) === null ){
                allMoves.push( { from: loc, to: currentLoc  });
    
                currentLoc = { row: currentLoc.row + dir.row, col : currentLoc.col + dir.col };
            }

            if( BlackPawn.isOnBoard( currentLoc ) && moveOn.pieceAt(currentLoc)){
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