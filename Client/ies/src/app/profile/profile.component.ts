import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Profile } from '../models/profile';

import { Student, User } from '../models/user';
import { AuthService } from '../services/auth.service';
import { ProfileService } from '../services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  profile = new Profile

  user = new Student()
  constructor(private authSrv: AuthService, private snackBar: MatSnackBar, private profileService: ProfileService) {
  }

  ngOnInit(): void {
    this.authSrv.getCurrentUserProfile().subscribe({
      next: (profile) => {
        this.profile = profile;
      }
    });
  }

  onSubmit(data: any): void {
    debugger
    this.profileService.updateProfile(data).subscribe({
      next: () => {
        this.snackBar.open("Profile updated successfully", "OK", { duration: 5000 });
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
      this.snackBar.open(error.message, "OK", { duration: 5000 });
  }
}
