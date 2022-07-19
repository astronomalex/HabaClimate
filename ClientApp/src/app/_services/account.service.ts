import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable, ReplaySubject} from 'rxjs';
import {environment} from 'src/environments/environment';
import {User} from "../_models/User";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  httpOptions = environment.httpOptions;
  private currentUserSource = new ReplaySubject<User | null>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {
  }

  login(model: any): Observable<any> {
    return this.http.post(this.baseUrl + 'account/login', model, this.httpOptions)
      //   .pipe(
      //   map((response: User) => {
      //     const user = response;
      //     if (user) {
      //       this.setCurrentUser(user);
      //     }
      //   })
      // )
      ;
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model, this.httpOptions)
      //   .pipe(
      //   map((user: User) => {
      //     if(user) {
      //       this.setCurrentUser(user);
      //     }
      //   })
      // )
      ;
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
