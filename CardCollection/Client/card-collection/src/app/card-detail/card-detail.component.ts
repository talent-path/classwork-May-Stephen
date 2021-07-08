import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { card } from 'src/models/card';
import { CardService } from 'src/services/card-service';

@Component({
  selector: 'app-card-detail',
  templateUrl: './card-detail.component.html',
  styleUrls: ['./card-detail.component.css']
})
export class CardDetailComponent implements OnInit {

  @Input()
  cardId!: string;

  card!: card;

  constructor(private service : CardService, private router : ActivatedRoute) { }

  ngOnInit(): void {
    this.cardId = this.router.snapshot.params['id'];
    this.service.getCardById(this.cardId).subscribe(result => {
      this.card = result;

    })
  }

  

}
