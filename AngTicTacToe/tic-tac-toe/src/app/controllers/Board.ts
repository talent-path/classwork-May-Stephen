import { Position } from "./Position";
import { Spots } from "./Spots"

export interface Board {
    allSquares : string[][];
    isXTurn: boolean;
}

export class TicBoard implements Board {
     
    
    isXTurn: boolean = false;
    allSquares: string[][] = [];

    constructor(toCopy?: Board) {
        if(toCopy) {
            this.buildFrom(toCopy);
        }
        
        this.allSquares.push([],[],[]);
        for ( let i = 0; i < this.allSquares.length; i++) {
            for (let j = 0; j < 3; j++) {
                this.allSquares[i].push(null);
            }
        }
    }

     locationAt(loc: Position): string {
         return this.allSquares[loc.row][loc.col]
     }

     changeTurn() : void {
        this.isXTurn = !this.isXTurn;
      }

      buildFrom(toCopy : Board) {
        this.allSquares = [];
        for( let i = 0; i < toCopy.allSquares.length; i++) {
            this.allSquares.push([...toCopy.allSquares[i]]);
        }


      }

      makeMove(pos : Position) : void {
            let nextBoard: TicBoard = new TicBoard(this);

            nextBoard.allSquares[pos.row][pos.col] = this.isXTurn ? "x" : "o";
            this.isXTurn = !this.isXTurn;

      }
}