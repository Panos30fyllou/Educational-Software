import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})


export class NavigationComponent implements OnInit {

  @ViewChild('sidenav') public sidenav: MatSidenav | undefined;

  isLoggedIn: boolean = false;

  constructor() { }

  ngOnInit(): void {


  }

}
