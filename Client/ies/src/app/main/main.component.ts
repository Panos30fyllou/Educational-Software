import { Component, OnInit } from '@angular/core';
import { Lesson } from '../models/lesson';
import { LessonListItem } from '../models/lesson-list-item';
import { LessonsService } from '../services/lessons.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  lessons: LessonListItem[] = [];
  lessonIds: number[] = [];

  constructor(private lessonsSrv: LessonsService) { }

  ngOnInit(): void {
    this.lessonsSrv.getLessonListItems().subscribe({
      next: (res) => {
        this.lessons = res;
        this.lessons.forEach(lesson => {
          this.lessonIds = [];
          this.lessonIds.push(lesson.lessonId);
        });
      }
    })
  }
}
