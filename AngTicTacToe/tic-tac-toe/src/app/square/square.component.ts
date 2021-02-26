import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { TicBoard } from '../controllers/Board';
import { Spots } from '../controllers/Spots';


@Component({
  selector: 'app-square',
  templateUrl: './square.component.html',
  styleUrls: ['./square.component.css']
})
export class SquareComponent implements OnInit {

  @Output() clickEvent : EventEmitter<{
    row: number;
    col: number;
  }> = new EventEmitter<{
    row: number;
    col: number;
  }>();

  imageSrc : string =" ";
  @Input()row : number = 0;
  @Input()col : number = 0;
  isXTurn : boolean = true;
  

  constructor() { }

  ngOnInit(): void {
    
  }

  onClick() : void {
    
    this.clickEvent.emit({row: this.row, col: this.col})
    this.imageSrc = "./assets/";
    this.imageSrc += this.isXTurn ? "x" : "o";
    this.imageSrc += ".png";
  
  }

  

  

  

}
