import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { card } from 'src/models/card';
import { CardService } from 'src/services/card-service';

@Component({
  selector: 'app-card-list',
  templateUrl: './card-list.component.html',
  styleUrls: ['./card-list.component.css']
})
export class CardListComponent implements OnInit {


  cards!: card[];

  constructor(private service : CardService, private router : Router) { }

  ngOnInit(): void {
    this.service.getCardsBySet().subscribe(result => {
      this.cards = result;

    })
  }
}
