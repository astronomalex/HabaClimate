import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree} from '@angular/router';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {AccountService} from '../_services/account.service';
import {ToastrService} from 'ngx-toastr';
import {Token} from "@angular/compiler";
import {TokenStorageService} from "../_services/token-storage.service";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private tokenService: TokenStorageService, private toastr: ToastrService) {}

  canActivate(): Observable<boolean> {
    return this.tokenService.getUser().asObservable();
  }

}
