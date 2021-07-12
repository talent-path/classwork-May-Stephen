import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { count } from 'rxjs/operators';
import { CollectionService } from 'src/services/collection-service';

@Component({
  selector: 'app-progress-bar',
  templateUrl: './progress-bar.component.html',
  styleUrls: ['./progress-bar.component.css']
})
export class ProgressBarComponent implements OnInit {

  

  @Input() id!: string;
  count !: any;
  max : any;



  constructor(private service : CollectionService, private router : Router) {
    
   }

  ngOnInit(): void {
    
  }

  getSetCount()  {
    this.service.getSetCount(this.id).subscribe(res => {
      this.count = res;
    })
    
    
  }

  getSetTotalCount() {
    this.service.getSetTotal(this.id).subscribe(res => {
      this.max = res;
    });

  }

  setProgress() : string {
    let num = this.count / this.max;
    return num + "%";
    
  }

}
