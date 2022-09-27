import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {
  isLoggedIn: boolean = false;

  constructor(private auth: AuthService) { }
  canActivate(): boolean {
    console.log(this.auth.checkLoginStatus)
    this.auth.IsLoggedIn$.subscribe({ next: (res) => { this.isLoggedIn = res } });
    return this.isLoggedIn;
  }

}
