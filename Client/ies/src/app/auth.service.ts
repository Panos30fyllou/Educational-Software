import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  private isLoggedIn$?: Observable<string>;

  constructor(private router: Router) {
    this.isLoggedIn.next(localStorage.getItem("isLoggedIn") == "true");
  }

  logOut(): void {
    this.isLoggedIn.next(false);
    localStorage.removeItem("isLoggedIn");
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

  setUsername(username: string) {
    localStorage.setItem("username", username);
  }

  get getUsername() {
    return localStorage.getItem("username");
  }
}
