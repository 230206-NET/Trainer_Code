import { Component, EventEmitter, Input, Output } from '@angular/core';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  @Output() showCreate = new EventEmitter<boolean>();
  @Input() create : boolean = false;
  toggleCreate() : void {
    this.create = !this.create;
    this.showCreate.emit(this.create);
  } 
}