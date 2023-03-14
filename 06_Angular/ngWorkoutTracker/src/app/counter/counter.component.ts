import { Component } from '@angular/core';

@Component({
  selector: 'app-counterComp',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})
export class CounterComponent {
  count : number = 0;

  increment() : void {
    this.count = this.count + 1;
  }

  arr : number[] = [1,2,3,4,5];

  show : Boolean = true;

  toggleShow(e: Event) : void {
    console.log(e);
    this.show = !this.show;
  }
}