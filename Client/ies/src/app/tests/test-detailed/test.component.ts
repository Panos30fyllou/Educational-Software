import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Test } from 'src/app/models/test';
import { TestsService } from 'src/app/services/tests.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  public test: Test;
  public routeSub?: Subscription;
  constructor(private route: ActivatedRoute, private testsService: TestsService) {
    this.test = new Test();
  }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.testsService.generateTest(params['chapterId']).subscribe({ next: (test) => this.test = test })
    });
  }

  ngOnDestroy() {
    this.routeSub?.unsubscribe();
  }
}
