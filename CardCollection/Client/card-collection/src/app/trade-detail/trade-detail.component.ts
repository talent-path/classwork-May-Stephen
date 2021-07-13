import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { card } from 'src/models/card';
import { User } from 'src/models/user';
import { TradeService } from 'src/services/trade-service';

@Component({
  selector: 'app-trade-detail',
  templateUrl: './trade-detail.component.html',
  styleUrls: ['./trade-detail.component.css']
})
export class TradeDetailComponent implements OnInit {

  tradeId!: number;
  cards!: card[];
  requests!: card[];
  user!: User;

  constructor(private service : TradeService, private router: ActivatedRoute) { }

  ngOnInit(): void {
    this.tradeId = this.router.snapshot.params['tradeId'];
    this.service.getCardsByTradeId(this.tradeId).subscribe(x => {
      this.cards = x;
    });

    this.service.getTradeUserName(this.tradeId).subscribe(x => {
      this.user = x;
    });
  }

}
