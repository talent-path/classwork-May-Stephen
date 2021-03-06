"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
exports.__esModule = true;
exports.King = void 0;
var ChessPiece_1 = require("./ChessPiece");
var Piece_1 = require("./Piece");
var King = /** @class */ (function (_super) {
    __extends(King, _super);
    function King(isWhite) {
        var _this = _super.call(this, Piece_1.PieceType.King, isWhite) || this;
        _this.generateMoves = function (moveOn, loc) {
            _this.inCheck(moveOn);
            var kingMoves = [];
            //we'll generate 4 "position" objects that represent different directions the king might move
            //then try those one at a time and add the results
            var kingDirections = [];
            kingDirections.push({ row: 1, col: 1 });
            kingDirections.push({ row: 1, col: -1 });
            kingDirections.push({ row: -1, col: 1 });
            kingDirections.push({ row: -1, col: -1 });
            kingDirections.push({ row: 1, col: 0 });
            kingDirections.push({ row: -1, col: 0 });
            kingDirections.push({ row: 0, col: 1 });
            kingDirections.push({ row: 0, col: -1 });
            for (var _i = 0, kingDirections_1 = kingDirections; _i < kingDirections_1.length; _i++) {
                var direction = kingDirections_1[_i];
                var directionMoves = King.slidePiece(moveOn, loc, direction, _this.isWhite);
                kingMoves.push.apply(kingMoves, directionMoves);
            }
            return kingMoves;
        };
        _this.inCheck = function (moveOn, currentSpot, endSpot, isWhite) {
            var opposingPieces = [];
            for (var _i = 0, _a = moveOn.allSquares; _i < _a.length; _i++) {
                var row = _a[_i];
                console.log(row);
                for (var _b = 0, row_1 = row; _b < row_1.length; _b++) {
                    var piece = row_1[_b];
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
        };
        return _this;
    }
    King.isOnBoard = function (loc) {
        return loc.col >= 0 && loc.col < 8 && loc.row >= 0 && loc.row < 8;
    };
    King.slidePiece = function (moveOn, loc, dir, isWhite) {
        var allMoves = [];
        var currentLoc = { row: loc.row + dir.row, col: loc.col + dir.col };
        if (King.isOnBoard(currentLoc) && moveOn.pieceAt(currentLoc) === null) {
            allMoves.push({ from: loc, to: currentLoc });
            currentLoc = { row: currentLoc.row + dir.row, col: currentLoc.col + dir.col };
        }
        if (King.isOnBoard(currentLoc) && moveOn.pieceAt(currentLoc)) {
            console.log(currentLoc);
            if (moveOn.pieceAt(currentLoc).isWhite != isWhite) {
                allMoves.push({ from: loc, to: currentLoc });
            }
        }
        return allMoves;
    };
    return King;
}(ChessPiece_1.ChessPiece));
exports.King = King;
