import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { CartComponent } from './cart/cart.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { RegisterComponent } from './register/register.component';
import { ReviewsComponent } from './reviews/reviews.component';

const routes: Routes = [
  {path: '',component: HomeComponent},

  {path: 'login',component : LoginComponent},
    {path: 'home',component: HomeComponent},
   {path: 'Menu',component: MenuComponent},
    {path: 'reviwes',component: ReviewsComponent,canActivate:[AuthGuard]},
    {path: 'register',component : RegisterComponent},
    {path: 'cart',component:CartComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
