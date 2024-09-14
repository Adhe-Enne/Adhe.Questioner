import { Routes } from '@angular/router';
import { WelcomeComponent } from './welcome/welcome.component';
//import { HomeComponent } from './home/home.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';

export const routes: Routes = [
  { path: '', redirectTo: "/welcome", pathMatch: 'full' },
  { path: 'welcome', component: WelcomeComponent },
  // { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: "/welcome", pathMatch: 'full' },
];

