import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {FormBuilder, FormControl} from '@angular/forms';
import { FoxImage } from '../app-image-services';
import { NgIf } from '@angular/common';
import { ImageService } from '../app-image-services';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  
  constructor(private _http: HttpClient, private formBuilder : FormBuilder, private service : ImageService){}
  ngOnInit() {
      this.getImage().then((data) => {
        this.image = data;
      });
  }

  display : boolean = true;
  url : string = "https://static.wikia.nocookie.net/disney/images/5/5e/Profile_-_Peter_Pan.jpeg"
  foxUrl : string = "https://randomfox.ca/floof"
  image: string = '';
  text: string = '';

  displayimage(e: Event) : void{
    console.log(e);
  }

  textInput: FormControl = new FormControl('')

  // getImage() : void{
  //   this._http.get("https://randomfox.ca/floof").subscribe((data: any) => {
  //     this.image = data['image'];

  //   });
  //   console.log("This function has been called!!!");
  // }

  async getImage() : Promise<any> {
    // this.service.getImage(this.foxUrl).subscribe((data : FoxImage) => {
    //     this.image = data['image'];
    //     console.log('data came)');
    // });
    this.image = await this.service.getImage(this.foxUrl)
  }


  getInput() : void {
    this.text = this.textInput.value;
  }
}
