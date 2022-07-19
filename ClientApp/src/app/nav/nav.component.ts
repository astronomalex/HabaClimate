import {Component, OnInit} from '@angular/core';
import {AccountService} from '../_services/account.service';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';
import {TokenStorageService} from "../_services/token-storage.service";
import {User} from "../_models/User";
import {of} from "rxjs";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  user: User | undefined;

  constructor(
    public accountService: AccountService,
    private router: Router,
    public tokenService: TokenStorageService,
    private toastr: ToastrService) {
  }

  ngOnInit(): void {
    if (this.tokenService.getToken()) {
      this.isLoggedIn = true;
    }
  }

  login(): void {
    this.accountService.login(this.model).subscribe({
      next: response => {
        this.tokenService.saveToken(response.token);
        this.tokenService.saveUser(response);
        this.accountService.currentUser$ = of(response);
        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.router.navigateByUrl('/adminPanel');
      },
      error: err => {
        this.errorMessage = err.error.message;
        this.toastr.error(this.errorMessage);
        this.isLoginFailed = true;
        this.accountService.currentUser$ = of(null);
      }
    })

    // this.accountService.login(this.model).subscribe({
    //     next: response => {
    //
    //     }
    //   }
    //   //   responce => {
    //   //   this.router.navigateByUrl('/admin-panel');
    //   // }, error => {
    //   //   this.toastr.error(error.error);
    //   //   console.log(error);
    //   // }
    // );
  }

  logout(): void {
    this.tokenService.signOut();
    this.accountService.currentUser$ = of(null);
    this.isLoggedIn = false;
    this.router.navigateByUrl('/');
  }
}
