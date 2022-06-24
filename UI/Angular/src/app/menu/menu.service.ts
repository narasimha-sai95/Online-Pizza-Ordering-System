import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Menu } from '../menu/models/menu.model';


@Injectable({
  providedIn: 'root'
})
export class MenuService {

  constructor(private http: HttpClient) { }
baseUrl="https://localhost:7180/api/Pizzas"
  //Get all pizzas
  getAllPizzas(): Observable<Menu[]>{
return this.http.get<Menu[]>(this.baseUrl);
  }
}
