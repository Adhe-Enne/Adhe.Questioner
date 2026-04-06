import { Component } from '@angular/core';
//import { interval } from 'rxjs';

@Component({
  selector: 'app-event-binding',
  standalone: true,
  imports: [],
  templateUrl: './event-binding.component.html',
  styleUrl: './event-binding.component.css'
})

export class EventBindingComponent {

  title: string = 'Questioner.Site';
  text: string = 'This is a video about event binding';
  textoPlaceHolder: string = "Escriba algo aqui, es seguro y sensual";
  disable: boolean = true;
  imgSrc: string = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/6ef2ac77-f635-4fb1-b1b4-2bb99461f0bf/de5fv6d-d8ac0d12-f5cb-46b7-9a98-67c1b84a75ba.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzZlZjJhYzc3LWY2MzUtNGZiMS1iMWI0LTJiYjk5NDYxZjBiZlwvZGU1ZnY2ZC1kOGFjMGQxMi1mNWNiLTQ2YjctOWE5OC02N2MxYjg0YTc1YmEucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.FY_KGIOttXe2LcZquhCcFjpxVm_OM2dlaYPsR2pVRLo";
  /*constructor()
    {
      //interval(3000).subscribe(() => this.title = "Capa Front");
      //setInterval(() =>this.disable = false, 3000);
    }*/

  getSuma(num: number, num2: number) {
    return num + num2;
  }

  changeText(): void {
    this.text = "In the next video we talk about of \"Two way data-binding\" ";
  }

  ngOnInit(): void {
  }
}
