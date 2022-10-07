import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Chapter } from 'src/app/models/chapter';
import { LessonsService } from 'src/app/services/lessons.service';
import { TestsService } from 'src/app/services/tests.service';
import { Test } from '../../models/test';

@Component({
  selector: 'app-tests',
  templateUrl: './tests.component.html',
  styleUrls: ['./tests.component.scss']
})
export class TestsComponent implements OnInit {
  tests: Test[] = [];
  chapters: Chapter[] = [];
  startingChapterId?: number;
  endingChapterId?: number;

  constructor(private lessonsSrv: LessonsService, private router: Router) { }

  ngOnInit(): void {
    this.lessonsSrv.getChapters().subscribe({
      next: (chapters) => {
        this.chapters = chapters;
        this.startingChapterId = chapters[0].chapterId;
        this.endingChapterId = chapters[chapters.length - 1].chapterId;
      }
    });
  }

  generateNewTest() {
    this.router.navigate([`/test/${this.startingChapterId}/${this.endingChapterId}`]);
  }
}
