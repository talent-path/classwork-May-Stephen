import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { card } from "src/models/card";
import {tap, catchError, map} from 'rxjs/operators';
import { Observable, of, pipe } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class CardService {
    url: string = "https://localhost:44345/"

    httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})}

    result!: card;

    constructor(private http : HttpClient) { }


    getCardById() : Observable<card> {
        return this.http.get<card>(this.url + "Cards/base1-2")
        .pipe(
            tap( x => console.log(x)),
            catchError(err => {
                console.log(err);
                return of(this.result);
            })
        )
    }

    getCardsBySet() : Observable<card[]> {
        return this.http.get<card[]>(this.url + "Cards/Set/base1")
        .pipe(
            tap(x => console.log(x)),
            catchError(err => {
                console.log(err);
                let empty : card[] = [];
                return of(empty)
            })
        )
    }
}