import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Student } from '../models/user';
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
  data: Student = new Student();

  constructor(private loginService: LoginService, private snackBar: MatSnackBar, private router: Router) {
  }

  ngOnInit(): void { }

  ngOnDestroy(): void {
    this.registerSubscription.unsubscribe();
  }

  onSubmit(): void {
    if (this.passwordConfirm == this.data.password)
      this.registerSubscription = this.loginService.register(this.data).subscribe((success) => (this.snackBar.open("User successfully registered", "OK", { duration: 5000 }), this.router.navigate(["/login"])), (err) => this.handleError(err));
    else
      this.snackBar.open("Passwords don't match", "OK", { duration: 5000 });
  }

  handleError(error: HttpErrorResponse) {
    if (error instanceof ErrorEvent)
      this.snackBar.open("A Client-Side error occured!", "OK", { duration: 5000 });
    else
      this.snackBar.open(error.error, "OK", { duration: 5000 });
  }
}
