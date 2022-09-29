import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { SidenavService } from '../services/sidenav.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})


export class HeaderComponent implements OnInit {

  @Input() sidenav: MatSidenav | undefined;

  constructor(private sidenavService: SidenavService) {
  }

  ngOnInit(): void {

  }
}
