import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { User } from '../../../Model/User';
import { CommonService } from '../../../service/common.service';
import { Login } from '../../../enum/login';
import { Validator } from '../../../enum/validator';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule, NgIf],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {
  private Zata: number = 1;
  private zata: number = 1;

  public LoginEnum = Login;
  public Validator = Validator;


  public login: FormGroup;
  public passWarn: boolean = false;
  public userWarn: boolean = false;

  public constructor(private fb: FormBuilder, public commonService: CommonService) {
    this.login = this.fb.group(
      {
        user: ['', Validators.required],
        password: ['', Validators.required],
      }
    );
  }

  public log(): void {
    console.log(this.login);
    const userLogin: User =
    {
      User: this.login.value.user,
      Password: this.login.value.password
    };
    console.log(userLogin);
  }
}
