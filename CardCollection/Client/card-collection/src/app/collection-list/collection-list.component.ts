import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { card } from 'src/models/card';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-collection-list',
  templateUrl: './collection-list.component.html',
  styleUrls: ['./collection-list.component.css']
})
export class CollectionListComponent implements OnInit {


  userId: number = 0;
  @Input() cardId!: string;
  cards!: card[];
  
  constructor(private service : CollectionService, private router: Router) 
  {
    
   }

  ngOnInit(): void {
    let u = JSON.parse(localStorage.getItem('user') || '{}');
    this.userId = u.id;
    this.service.getCollection(this.userId).subscribe(res => {
      this.cards = res;
    })
  }

}
