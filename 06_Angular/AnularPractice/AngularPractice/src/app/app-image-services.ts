import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable, firstValueFrom} from 'rxjs';

export type FoxImage = {
    image: string
}
@Injectable({
    providedIn: 'root'
})
export class ImageService {
    url : string = "https://randomfox.ca/floof"
    image : string = ""
    constructor(private http: HttpClient) { }
    async getImage(url : string): Promise<string>{
        // return fetch(url); 
        const data = await firstValueFrom(this.http.get(url)) as any
        return data['image'] as string;

        // fetch(url).then((res) => res.json()).then(data => {

        // })
    }
}