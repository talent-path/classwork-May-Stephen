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
exports.WhitePawn = void 0;
var ChessPiece_1 = require("./ChessPiece");
var Piece_1 = require("./Piece");
var WhitePawn = /** @class */ (function (_super) {
    __extends(WhitePawn, _super);
    function WhitePawn() {
        var _this = _super.call(this, Piece_1.PieceType.Pawn, true) || this;
        _this.turnCount = 0;
        _this.generateMoves = function (moveOn, loc) {
            var PawnMoves = [];
            //we'll generate 4 "position" objects that represent different directions the pawn might move
            //then try those one at a time and add the results
            var pawnDirections = [];
            var leftDiag = { row: loc.row + 1, col: loc.col + 1 };
            var rightDiag = { row: loc.row + 1, col: loc.col - 1 };
            pawnDirections.push({ row: 1, col: 0 });
            if (_this.turnCount === 0) {
                pawnDirections.push({ row: 2, col: 0 });
            }
            if (WhitePawn.isOnBoard(leftDiag) && moveOn.pieceAt(leftDiag) !== null) {
                if (moveOn.pieceAt(leftDiag).isWhite != _this.isWhite) {
                    pawnDirections.push({ row: 1, col: -1 });
                }
            }
            if (WhitePawn.isOnBoard(rightDiag) && moveOn.pieceAt(rightDiag) !== null) {
                if (moveOn.pieceAt(rightDiag).isWhite != _this.isWhite) {
                    pawnDirections.push({ row: 1, col: 1 });
                }
            }
            for (var _i = 0, pawnDirections_1 = pawnDirections; _i < pawnDirections_1.length; _i++) {
                var direction = pawnDirections_1[_i];
                var directionMoves = WhitePawn.slidePiece(moveOn, loc, direction, _this.isWhite);
                PawnMoves.push.apply(PawnMoves, directionMoves);
            }
            return PawnMoves;
        };
        return _this;
    }
    WhitePawn.isOnBoard = function (loc) {
        return loc.col >= 0 && loc.col < 8 && loc.row >= 0 && loc.row < 8;
    };
    WhitePawn.slidePiece = function (moveOn, loc, dir, isWhite) {
        var allMoves = [];
        var currentLoc = { row: loc.row + dir.row, col: loc.col + dir.col };
        if (WhitePawn.isOnBoard(currentLoc) && moveOn.pieceAt(currentLoc) === null) {
            allMoves.push({ from: loc, to: currentLoc });
            currentLoc = { row: currentLoc.row + dir.row, col: currentLoc.col + dir.col };
        }
        if (WhitePawn.isOnBoard(currentLoc) && moveOn.pieceAt(currentLoc)) {
            console.log(currentLoc);
            if (moveOn.pieceAt(currentLoc).isWhite != isWhite) {
                allMoves.push({ from: loc, to: currentLoc });
            }
        }
        return allMoves;
    };
    return WhitePawn;
}(ChessPiece_1.ChessPiece));
exports.WhitePawn = WhitePawn;
