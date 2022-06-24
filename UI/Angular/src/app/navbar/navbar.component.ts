import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  IsLoggedIn(){
    
    return localStorage.getItem('token');
  }
  name=localStorage.getItem('username');

onLogout(){
localStorage.removeItem('token');
localStorage.removeItem('username');

this.router.navigate(['/login'])
}
}
