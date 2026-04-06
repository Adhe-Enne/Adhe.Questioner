import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgClass, NgFor, NgIf, NgStyle } from '@angular/common';
import { Student } from '../../Model/student.model';
import { Item } from '../../Model/item.model';

@Component({
  selector: 'app-styles-table',
  standalone: true,
  imports: [NgFor, NgIf, NgStyle, NgClass],
  templateUrl: './styles-table.component.html',
  styleUrl: './styles-table.component.css'
})
export class StylesTableComponent {
  show: boolean = false;

  listEstudiantes: Student[] = [
    { Name: 'Tomas Gonzalez', Status: 'Promocionado' },
    { Name: 'Lucas Perez', Status: 'Regular' },
    { Name: 'Tomas Garcia', Status: 'Regular' },
    { Name: 'Juan Garcia', Status: 'Promocionado' },
    { Name: 'Juan Vega', Status: 'Libre' },
    { Name: 'La Roca', Status: 'Libre' }
  ];

  states: Item[] = [
    { Key: 'Promocionado', Text: 'success' },
    { Key: 'Regular', Text: 'secondary' },
    { Key: 'Libre', Text: 'danger' },

  ];

  ngOnInit(): void {
  }

  toggle(): void {
    this.show = true;
  }

  validateStatus(studet: Student): string | undefined {
    return this.states.find(x => x.Key == studet.Status)?.Text;
  }
}
