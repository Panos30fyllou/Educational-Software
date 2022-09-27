import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedIn: boolean;
  
  constructor(private router: Router) {
    this.isLoggedIn = localStorage.getItem("isLoggedIn") === "true";
  }

  logOut(): void {
    this.isLoggedIn = false;
    localStorage.removeItem("isLoggedIn");
  }

  changeLoginStatusTrue(): void {
    this.isLoggedIn = true;
    localStorage.setItem("isLoggedIn", "true");
  }

  get checkLoginStatus(): boolean {
    return this.isLoggedIn;
  }

  setUsername(username: string) {
    localStorage.setItem("username", username);
  }

  get getUsername() {
    return localStorage.getItem("username");
  }
}
