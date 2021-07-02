import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { card } from 'src/models/card';
import { CardService } from 'src/services/card-service';

@Component({
  selector: 'app-card-detail',
  templateUrl: './card-detail.component.html',
  styleUrls: ['./card-detail.component.css']
})
export class CardDetailComponent implements OnInit {

  @Input()
  card!: card;

  constructor(private service : CardService, private router : Router) { }

  ngOnInit(): void {
    this.service.getCardById().subscribe(result => {
      this.card = result;

    })
  }

  

}
