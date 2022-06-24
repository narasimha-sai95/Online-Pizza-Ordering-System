import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { LoginoutService } from 'src/app/loginoutService/loginout.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm=this.formbuilder.group({
    username: ['', [Validators.required]],
    password: ['', Validators.required]
  })
   constructor(private formbuilder:FormBuilder,private router:Router,private LoginoutService:LoginoutService,) { }

  ngOnInit(): void {
  }
   onSubmitLogin(){
    console.log("HI");
    let userName = this.loginForm.controls["username"].value;
    
     let password = this.loginForm.controls["password"].value;

     this.LoginoutService.login(userName,password).subscribe((data:any)=>{
       if(data.token !=null){
        alert('Login SuccessFull');

   //  console.log(data.token);
     localStorage.setItem('token',data.token);
localStorage.setItem('username',data.username);
     this.router.navigate(['/Menu'])
     console.log('display token',localStorage.getItem('token'))
     console.log('display username',localStorage.getItem('username'))

    }
     else{

       alert('Please try again');
     }
   
       console.log("response",data)
     },error=>{
       console.log("error",error)
    })
  }



}
