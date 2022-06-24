import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { MenuComponent } from '../menu/menu.component';
import { Menu } from '../menu/models/menu.model';
import { Cart } from './cart.module';




@Injectable({
  providedIn: 'root'
})
export class CartService {
  cartItems : any = [];
  Cart : Cart[]=[];
  public productList = new BehaviorSubject<any>([]);
  constructor() { }

  AddtoCart(menu : any){
   
this.cartItems.push(menu);

console.log('log',menu);
this.productList.next(this.cartItems);




  }
  getProducts()
  {
    return this.productList.asObservable();

  }


}
