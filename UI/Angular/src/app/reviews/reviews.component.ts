import { Component, OnInit } from '@angular/core';
import { Reviews } from './models/reviews.model';
import { ReviewsService } from './reviews.service';
@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit {
  review:Reviews[]=[];
         // this is example data but you can use any object to pass to the table

  constructor(private reviewservice:ReviewsService) { }


  ngOnInit(): void {
    this.getAllreviews();
  }
  getAllreviews(){
    this.reviewservice.getAllreviews().subscribe(
      response=>{
        this.review=response;
        console.log(response);
      }
    )
  }

}
