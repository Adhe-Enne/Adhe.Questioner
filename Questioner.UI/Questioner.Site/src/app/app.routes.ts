import { Routes } from '@angular/router';
import { WelcomeComponent } from './welcome/welcome.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ChangepassComponent } from './dashboard/changepass/changepass.component';
import { QuestionnaireComponent } from './dashboard/questionnaire/questionnaire.component';

export const routes: Routes = [
  { path: '', redirectTo: "/home", pathMatch: 'full' },
  {
    path: 'home', component: HomeComponent, children: [
      { path: '', component: WelcomeComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent },
    ]
  },
  {
    path: 'dashboard', component: DashboardComponent, children: [
      { path: '', component: QuestionnaireComponent },
      { path: 'changepass', component: ChangepassComponent }
    ]
  },
  { path: '**', redirectTo: "/home", pathMatch: 'full' },
];
