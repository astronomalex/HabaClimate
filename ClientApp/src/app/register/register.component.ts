// import {Component, EventEmitter, OnInit, Output} from '@angular/core';
// import {AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators} from '@angular/forms';
// import {Router} from '@angular/router';
// import {AccountService} from '../_services/account.service';
// import {ToastrService} from 'ngx-toastr';
//
// @Component({
//   selector: 'app-register',
//   templateUrl: './register.component.html',
//   styleUrls: ['./register.component.css']
// })
// export class RegisterComponent implements OnInit {
//   @Output() cancelRegister = new EventEmitter();
//   registerForm: FormGroup;
//   maxDate: Date;
//   validationErrors: string[] = [];
//
//   constructor(private accountService: AccountService,
//               private fb: FormBuilder,
//               private router: Router,
//               private toastr: ToastrService) {
//   }
//
//   ngOnInit(): void {
//     this.initializeForm();
//     this.maxDate = new Date;
//     this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
//   }
//
//   initializeForm() {
//     this.registerForm = this.fb.group({
//       gender: ['male'],
//       username: ['', Validators.required],
//       knownAs: ['', Validators.required],
//       dateOfBirth: ['', Validators.required],
//       city: ['', Validators.required],
//       country: ['', Validators.required],
//       password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
//       confirmPassword: ['', [Validators.required, this.matchValues('password')]]
//     });
//   }
//
//   matchValues(matchTo: string): ValidatorFn {
//     return (control: AbstractControl) => {
//       return control?.value === control?.parent?.controls[matchTo].value ? null : {isMatching: true};
//     };
//   }
//
//   register() {
//     this.accountService.register(this.registerForm.value).subscribe(() => {
//       this.router.navigateByUrl('/members');
//     }, (error: string[]) => {
//       this.validationErrors = error;
//       this.toastr.error(error[0]);
//     });
//   }
//
//   cancel() {
//     this.cancelRegister.emit(false);
//   }
//
// }
import { Component, OnInit } from '@angular/core';
import {AccountService} from "../_services/account.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: any = {
    username: null,
    email: null,
    password: null
  };
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const { username, password } = this.form;

    this.accountService.register({username, password}).subscribe({
      next: data => {
        console.log(data);
        this.isSuccessful = true;
        this.isSignUpFailed = false;
      },
      error: err => {
        this.errorMessage = err.error.message;
        this.isSignUpFailed = true;
      }
    });
  }
}
