import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'test-control',
  templateUrl: './test-control.component.html',
  styleUrls: ['./test-control.component.css']
})
export class TestControlComponent implements OnInit {
  defaultImg : boolean = true;
  constructor() { }

  ngOnInit(): void {
  }

  imageSrc : string = "./assets/3408.jpg";


onClick() : void {
  this.defaultImg = !this.defaultImg;
  if (this.defaultImg) {
    this.imageSrc ="./assets/3408.jpg";
}
  else this.imageSrc = "https://content.fortune.com/wp-content/uploads/2019/01/boo.jpg?resize=1500,1000";

}





}
