import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { WelcomeComponent } from "./welcome/welcome.component";
import { HomeComponent } from './home/home.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, RouterOutlet, WelcomeComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  public title = 'Questioner.UI';

}
