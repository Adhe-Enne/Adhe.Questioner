import { JsonPipe, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommonService } from '../../../service/common.service';
import { Login } from '../../../enum/login';
import { Validator } from '../../../enum/validator';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, JsonPipe, RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})

export class RegisterComponent {
  public LoginEnum = Login;
  public Validator = Validator;
  public login: FormGroup;
  public passWarn: boolean = false;
  public userWarn: boolean = false;

  public constructor(private fb: FormBuilder, public comSrv: CommonService) {
    this.login = this.fb.nonNullable.group(
      {
        user: ['', Validators.required],
        password: ['', [Validators.required, Validators.minLength(4)]],
        rePassword: ['']
      },
      { validators: this.comSrv.customPasswordMatching.bind(this) }
    );
  }

  public log(): void {
    console.log(this.login);

    const userLogin =
    {
      User: this.login.value.user,
      Password: this.login.value.password,
      RePassword: this.login.value.rePassword
    };
    console.log(userLogin);
  }


}
