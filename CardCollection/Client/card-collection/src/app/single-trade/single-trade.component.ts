import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { card } from 'src/models/card';
import { trade } from 'src/models/trade';
import { User } from 'src/models/user';
import { TradeService } from 'src/services/trade-service';

@Component({
  selector: 'app-single-trade',
  templateUrl: './single-trade.component.html',
  styleUrls: ['./single-trade.component.css']
})
export class SingleTradeComponent implements OnInit {

  @Input()tradeId!: number;
  cards!: card[];
  user!: User;

  

  constructor(private service : TradeService, private router: Router) { }

  ngOnInit(): void {
    this.service.getCardsByTradeId(this.tradeId).subscribe(x => {
      this.cards = x;
    });

    this.service.getTradeUserName(this.tradeId).subscribe(x => {
      this.user = x;
    })
  }

}
