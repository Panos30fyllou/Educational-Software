import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { combineLatest } from 'rxjs';
import { LessonsService } from 'src/app/services/lessons.service';
import { LessonListItem } from '../../models/lesson-list-item';

@Component({
  selector: 'app-lessons',
  templateUrl: './lessons.component.html',
  styleUrls: ['./lessons.component.scss']
})
export class LessonsComponent implements OnInit {
  lessonIds: number[] = [];
  lessons: LessonListItem[] = []
  constructor(
    private lessonsSrv: LessonsService,
    private router: Router) { }

  ngOnInit(): void {
    this.lessonsSrv.getLessons$.subscribe({
      next: (res) => {
        this.lessons = res;
      }
    });

  }

  openLesson(id: number) {
    this.router.navigate([`/lesson/${id}`]);
  }
}
