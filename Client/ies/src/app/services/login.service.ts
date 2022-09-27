import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url: string = "";
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  login(data: Observable<User>) {
    this.url = environment.serverUrl + "/Users/Login";

    return this.http.post(this.url, data);
  }

  register(data: User) {
    this.url = environment.serverUrl + "/Users/Register";

    return this.http.post(this.url, data);
  }
}
