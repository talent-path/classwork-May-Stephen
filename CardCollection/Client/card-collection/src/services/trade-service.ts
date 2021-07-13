import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { card } from "src/models/card";
import { trade } from "src/models/trade";
import { User } from "src/models/user";

@Injectable({
    providedIn: 'root'
})
export class TradeService{
  
    url: string = "https://localhost:44345/"

    httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})}
    
    userId : number;

    constructor(private http : HttpClient, private router :Router ) {
        let u = JSON.parse(localStorage.getItem('user')  || '{}');
        this.userId = u.id;
     }

     getAllTrades() : Observable<trade[]> {
        return this.http.get<trade[]>(this.url + "Trades")
        .pipe(
            tap(),
            catchError(err => {
                console.log(err);
                let empty : trade[] = [];
                return of(empty)
            }
        ))
      }

      getCardsByTradeId(tradeId: number) {
        return this.http.get<card[]>(this.url + "Trades/Cards/" + tradeId)
        .pipe(
            tap(),
            catchError(err => {
                console.log(err);
                let empty : card[] = [];
                return of(empty)
            }
        ))
      }

      getTradeUserName(tradeId: number) : Observable<User> {
        return this.http.get<User>(this.url + "Trades/" + tradeId + "/user")
        .pipe(
          tap(),
      )
      }
}