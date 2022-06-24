import { Component, OnInit } from '@angular/core';
import { MenuComponent } from '../menu/menu.component';
import { Cart } from './cart.module';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})

export class CartComponent implements OnInit {
  cart : any = [];
  Adcart: Cart[]=[];
  constructor(private cartserice:CartService) { }

  ngOnInit(): void {
    this.getProducts();
  }
getProducts(){
  this.cartserice.getProducts().subscribe(
    response=>{
      this.Adcart=response;
      console.log('cart response',response);
    }
  )
}


}
