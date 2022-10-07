import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Profile } from '../models/profile';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  private isLoggedIn$?: Observable<string>;

  constructor(private http: HttpClient) {
    this.isLoggedIn.next(localStorage.getItem("isLoggedIn") == "true");
  }

  logOut(): void {
    this.isLoggedIn.next(false);
    localStorage.setItem("isLoggedIn", "false");
  }

  changeLoginStatusTrue(): void {
    this.isLoggedIn.next(true);
    localStorage.setItem("isLoggedIn", "true");
  }

  get IsLoggedIn$(): Observable<boolean> {
    return this.isLoggedIn.asObservable();
  }

  get checkLoginStatus(): Observable<boolean> {
    return this.isLoggedIn.asObservable();
  }

  getCurrentUserProfile(): Observable<Profile> {
    return this.http.get<Profile>(environment.serverUrl + `/Users/SelectById`, { params: new HttpParams().set("id", this.getUserId)});
  }

  setUserId(userId: string) {
    localStorage.setItem("userId", userId);
  }

  get getUserId() {
    return parseInt(localStorage.getItem("userId") ?? "");
  }
}
