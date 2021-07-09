import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { card } from "src/models/card";


@Injectable({
    providedIn: 'root'
})
export class CollectionService{
    
  
    url: string = "https://localhost:44345/"

    httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})}
    
    userId : number;
    card!: card;
    result!: card;

    constructor(private http : HttpClient, private router :Router ) {
        let u = JSON.parse(localStorage.getItem('user')  || '{}');
        this.userId = u.id;
     }
  
    getCollection(userId: number) : Observable<card[]>{
        return this.http.get<card[]>(this.url +"User/" + userId + "/Collection")
        .pipe(
            tap(),
            catchError(err => {
                console.log(err);
                let empty : card[] = [];
                return of(empty)
            })
        )
    }

    addToCollection(card : string) {
        console.log(this.url + "User/" + this.userId + "/Collection/Add/" + card)
        return this.http.post(this.url + "User/" + this.userId + "/Collection/Add/" + card, card, this.httpOptions).pipe(
            tap(),
            catchError(err => {
              alert(err.error);
              return of(null);
            })
          );
        }
}