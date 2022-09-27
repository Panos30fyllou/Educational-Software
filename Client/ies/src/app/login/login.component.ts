import { Component, OnDestroy, OnInit } from '@angular/core';

import { Subscription } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { LoginService } from '../services/login.service';

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
  
  constructor(private loginService: LoginService, private router: Router, private auth: AuthService, private snackBar: MatSnackBar) { }

  ngOnInit(): void { }

  ngOnDestroy() {
    this.loginSubscription.unsubscribe();
  }

  onSubmit(data: any): void {
    console.log(this.loginService.login(data))
    this.loginSubscription = this.loginService.login(data)
      .subscribe((success) => (this.message = "Successfull login", this.auth.setUsername(this.username), console.log(this.username), this.auth.changeLoginStatusTrue(), this.router.navigate(["/home"])),
        (error) => this.handleError(error));
  }

  handleError(error: HttpErrorResponse) {
    if (error instanceof ErrorEvent)
      this.snackBar.open("A Client-Side error occured!", "OK", { duration: 5000 });
    else
      this.snackBar.open(error.error, "OK", { duration: 5000 });
  }
}