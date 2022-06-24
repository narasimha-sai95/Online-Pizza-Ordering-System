import { Component, OnInit } from '@angular/core';
import { MenuService } from './menu.service';
import { Menu } from './models/menu.model';
import { CartService } from '../cart/cart.service';
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  title='menu';
  Menu: Menu[] = [];
  cartItems : any = [] ;
   gridColumns=6;
  starRating=5;

  constructor(private menuService: MenuService,private cartService:CartService){

  }
  ngOnInit(): void {
    this.getAllPizzas();
  }
  getAllPizzas(){
    this.menuService.getAllPizzas()
      .subscribe(
        response=>{
          this.Menu=response;
          console.log('menu',response);
  
        }
      )
  
  }



  onClick(data:any){
console.log(data);
this.cartService.AddtoCart(data)



  }


}
