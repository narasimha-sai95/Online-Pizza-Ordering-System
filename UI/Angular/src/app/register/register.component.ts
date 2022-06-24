import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginoutService } from '../loginoutService/loginout.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  
  public registerForm=this.formbuilder.group({
    username: ['', [Validators.required]],

    email: ['', [Validators.email, Validators.required]],
    password: ['', Validators.required]
  })
  constructor(private formbuilder:FormBuilder,private LoginoutService:LoginoutService,private router:Router) { }

  ngOnInit(): void {
  }
  onSubmitRegister(){
    console.log("HI");

    let userName = this.registerForm.controls["username"].value;
    let email = this.registerForm.controls["email"].value;
    let password = this.registerForm.controls["password"].value;
    if(this.registerForm.valid){  
          alert('Registered Succesfully');
  }

    this.LoginoutService.register(userName,email,password).subscribe((data)=>{
     this.router.navigate(['/login'])

    


      console.log("response",data)
    },error=>{
      console.log("error",error)
    })
  }

}
