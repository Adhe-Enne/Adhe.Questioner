import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonService } from '../../../service/common.service';
import { Login } from '../../../enum/login';
import { NgIf } from '@angular/common';
import { Validator } from '../../../enum/validator';

@Component({
  selector: 'app-changepass',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf],
  templateUrl: './changepass.component.html',
  styleUrl: './changepass.component.css'
})
export class ChangepassComponent {

  public LoginEnum = Login;
  public Validator = Validator;
  public changepass: FormGroup;

  public constructor(private fb: FormBuilder, public comSrv: CommonService) {
    this.changepass = this.fb.nonNullable.group(
      {
        lastPassword: ['', Validators.required],
        password: ['', [Validators.required, Validators.minLength(4)]],
        rePassword: ['']
      },
      { validators: this.comSrv.customPasswordMatching.bind(this) }
    );
  }

  public savePass(): void {
    console.log(this.changepass);
  }
}
