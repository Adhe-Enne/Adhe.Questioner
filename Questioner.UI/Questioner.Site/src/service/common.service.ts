import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
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
}
