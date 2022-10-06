import { Component, OnDestroy, OnInit } from '@angular/core';

import { Subscription } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

import { MatSnackBar } from '@angular/material/snack-bar';
import { LoginService } from '../services/login.service';
import { AuthService } from '../services/auth.service';
import { Student, User } from '../models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit, OnDestroy {
  loginSubscription: Subscription = new Subscription();
  loginResult?: string;
  message?: string;
  username: string = '';

  constructor(
    private loginService: LoginService,
    private router: Router,
    private auth: AuthService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void { }

  ngOnDestroy() {
    this.loginSubscription.unsubscribe();
  }

  onSubmit(data: any): void {
    this.loginService.login(data).subscribe({
      next: (user) => {
        this.message = "Successfull login";
        this.auth.setUserId((user as User ).userId.toString());
        this.auth.changeLoginStatusTrue();
        this.router.navigate(["/home"]);
      },
      error: (error) => {
        this.handleError(error);
      }
    });
  }

  handleError(error: HttpErrorResponse) {
    if (error instanceof ErrorEvent)
      this.snackBar.open("A Client-Side error occured!", "OK", { duration: 5000 });
    else
      this.snackBar.open(error.error, "OK", { duration: 5000 });
  }
}