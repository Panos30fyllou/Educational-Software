import { Component, OnInit } from '@angular/core';
import { Student, User } from '../models/user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  user = new Student()
  constructor() { }

  ngOnInit(): void {
  }

}
