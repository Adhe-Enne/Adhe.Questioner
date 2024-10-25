import { Injectable } from '@angular/core';
import { AbstractControl, FormGroup, ValidationErrors } from '@angular/forms';
import { Validator } from '../enum/validator';

@Injectable({
  providedIn: 'root'
})

export class CommonService {
  public areEqual(value: string, toValue: string): boolean {
    return (value === toValue);
  }

  public checkControl(form: FormGroup, controlName: string, validator: string = Validator.Required): boolean {
    return form.controls[controlName].hasError(validator) && form.controls[controlName].touched;
  }

  //   public customPasswordMatching2(control: AbstractControl): ValidationErrors |null {
  //   const ret = .areEqual(control.value.password, control.value.rePassword);
  //   return ret ? null : { passwordMismatchError: true };
  // }

  public customPasswordMatching = (control: AbstractControl): ValidationErrors | null => {
    const ret = this.areEqual(control.value.password, control.value.rePassword);
    return ret ? null : { passwordMismatchError: true };
  };
}