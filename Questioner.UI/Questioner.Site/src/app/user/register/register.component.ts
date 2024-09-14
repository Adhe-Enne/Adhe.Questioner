import { JsonPipe, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormBuilder, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonService } from '../../../service/common.service';
import { Login } from '../../../enum/login';
import { Validator } from '../../../enum/validator';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, RouterLink, JsonPipe],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})

export class RegisterComponent {
  public LoginEnum = Login;
  public Validator = Validator;
  public login: FormGroup;
  public passWarn: boolean = false;
  public userWarn: boolean = false;

  public constructor(private fb: FormBuilder, public commonService: CommonService) {
    this.login = this.fb.group(
      {
        user: ['', Validators.required],
        password: ['', [Validators.required, Validators.minLength(4)]],
        rePassword: ['']
      }, { validator: this.customPasswordMatching.bind(this) }
    );
  }

  public customPasswordMatching(control: AbstractControl): ValidationErrors | null {
    const ret = this.commonService.areEqual(control.value.password, control.value.rePassword);
    return ret ? null : { passwordMismatchError: true };
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
