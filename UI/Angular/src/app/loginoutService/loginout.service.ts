import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})

export class LoginoutService {

  baseUrl = "https://localhost:7180/"

  constructor(private httpClient : HttpClient) { }

public login(username:string,password:string){

  const body={
    Username:username,
    Password:password
  }
  return this.httpClient.post(this.baseUrl+"api/Authenticate/login",body);
}

public register(username:string,email:string,password:string){

  const body={
    Username:username,
    Email:email,
    Password:password
  }
  return this.httpClient.post(this.baseUrl+"api/Authenticate/register",body);
}


}
