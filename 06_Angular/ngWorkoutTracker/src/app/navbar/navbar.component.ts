import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  @Output() showCreate = new EventEmitter<boolean>();
  createView : boolean = false;
  toggleCreate() : void {
    this.createView = !this.createView;
    this.showCreate.emit(this.createView);
  }

  ngOnInit(): void {
      this.showCreate.emit(this.createView);
  }
}