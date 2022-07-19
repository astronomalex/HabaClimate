import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {AirConditioner} from "../_models/AirConditioner";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Good} from "../_models/Good";

@Injectable({
  providedIn: 'root'
})
export class ConditionersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getGoods(): Observable<Good[]> {
    return this.http.get<Good[]>(this.baseUrl + 'good');
  }
}
