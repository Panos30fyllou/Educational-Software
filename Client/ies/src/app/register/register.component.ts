import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { RegisterRequest } from '../models/register-request';
import { UserRole } from '../models/role';
import { LoginService } from '../services/login.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit, OnDestroy {

  registerSubscription: Subscription = new Subscription;
  registerResult?: string;
  message?: string;
  passwordConfirm: string = "";
  @Input()
  data: RegisterRequest = new RegisterRequest();
  roles: UserRole[] = [1, 2];

  constructor(private loginService: LoginService, private snackBar: MatSnackBar, private router: Router) {
  }

  ngOnInit(): void { }

  ngOnDestroy(): void {
    this.registerSubscription.unsubscribe();
  }

  onSubmit(): void {
    if (this.passwordConfirm == this.data.password) {
      this.registerSubscription = this.loginService.register(this.data).subscribe({
        next: () => {
          this.snackBar.open("User successfully registered", "OK", { duration: 5000 });
          this.router.navigate(["/login"])
        },
        error: (err) => this.handleError(err)
      });
    }
    else
      this.snackBar.open("Passwords don't match", "OK", { duration: 5000 });
  }

  handleError(error: HttpErrorResponse) {
    if (error instanceof ErrorEvent)
      this.snackBar.open("A Client-Side error occured!", "OK", { duration: 5000 });
    else
      this.snackBar.open(error.message, "OK", { duration: 5000 });
  }

  getRoleDescription(role: number) {
    return UserRole[role]
  }
}
