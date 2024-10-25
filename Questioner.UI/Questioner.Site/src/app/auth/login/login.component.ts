import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { User } from '../../../Model/User';
import { CommonService } from '../../../service/common.service';
import { Login } from '../../../enum/login';
import { Validator } from '../../../enum/validator';
import { ToastrService } from 'ngx-toastr';
import { Router, RouterLink } from '@angular/router';
import { LoadingComponent } from '../../shared/loading/loading.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, RouterLink, LoadingComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {
  public LoginEnum = Login;
  public Validator = Validator;

  public loading: boolean = false;
  public login: FormGroup;
  public passWarn: boolean = false;
  public userWarn: boolean = false;

  public constructor(private fb: FormBuilder, public comSrv: CommonService, private toast: ToastrService, private route: Router) {
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
    this.loading = true;

    setTimeout(() => {
      if (userLogin.User == 'dani' && userLogin.Password == 'dani')
        this.route.navigate(["/dashboard"]);
      else
        this.toast.error('Usuario o Contraseña Incorrecta', 'Error');
      this.login.reset();
      this.loading = false;
    }, 3000);

  }
}
