import { Component, OnInit } from '@angular/core';
import { Board, TicBoard } from '../controllers/Board';
import { Position } from '../controllers/Position';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {
  
  board : Board = new TicBoard();

  constructor() { }

  ngOnInit(): void {
    this.board = new TicBoard();
  }


  
}
