import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})

export class NavigationComponent implements OnInit {

  @ViewChild('sidenav') public sidenav: MatSidenav | undefined;

  isLoggedIn: boolean = false;

  constructor(private authSrv: AuthService) { }

  ngOnInit(): void {
    this.authSrv.IsLoggedIn$.subscribe({ next: (res) => this.isLoggedIn = res })
  }

  logout() {
    this.authSrv.logOut();
  }
}
