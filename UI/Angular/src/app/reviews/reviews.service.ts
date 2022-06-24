import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Reviews } from './models/reviews.model';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {

  constructor(private httpclient:HttpClient) { }

  baseurl = "https://localhost:7180/api/Review"

  getAllreviews(): Observable<Reviews[]>{
    return this.httpclient.get<Reviews[]>(this.baseurl);
  }
}
