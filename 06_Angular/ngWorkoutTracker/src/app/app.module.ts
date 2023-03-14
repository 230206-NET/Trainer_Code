import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CounterComponent } from './counter/counter.component';
import { ViewWorkoutsComponent } from './view-workouts/view-workouts.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CounterComponent,
    ViewWorkoutsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
