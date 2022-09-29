import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {
  isLoggedIn: boolean = false;

  constructor(private auth: AuthService, private router: Router) { }
  canActivate(): boolean {
    this.auth.IsLoggedIn$.subscribe({ next: (res) => { this.isLoggedIn = res } });
    if (!this.isLoggedIn)
      this.router.navigateByUrl('/login')
    return this.isLoggedIn;
  }

}
