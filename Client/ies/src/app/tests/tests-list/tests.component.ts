import { Component, OnInit } from '@angular/core';
import { Test } from '../../models/test';

@Component({
  selector: 'app-tests',
  templateUrl: './tests.component.html',
  styleUrls: ['./tests.component.scss']
})
export class TestsComponent implements OnInit {

  tests: Test[] = []

  constructor() { }

  ngOnInit(): void {

    for (let i = 0; i < 5; i++)
      this.tests.push(new Test())
  }

}
