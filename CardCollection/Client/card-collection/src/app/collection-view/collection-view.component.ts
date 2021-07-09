import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { card } from 'src/models/card';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-collection-view',
  templateUrl: './collection-view.component.html',
  styleUrls: ['./collection-view.component.css']
})
export class CollectionViewComponent implements OnInit {

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
