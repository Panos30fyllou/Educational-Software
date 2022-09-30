import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LessonsService } from 'src/app/services/lessons.service';
import { LessonListItem } from '../../models/lesson-list-item';

@Component({
  selector: 'app-lessons',
  templateUrl: './lessons.component.html',
  styleUrls: ['./lessons.component.scss']
})
export class LessonsComponent implements OnInit {

  lessons: LessonListItem[] = []
  constructor(
    private lessonsSrv: LessonsService,
    private router: Router) { }

  ngOnInit(): void {
    // for (let i = 0; i < 5; i++)
    //   this.lessons.push(new LessonListItem())
    this.lessonsSrv.getLessonListItems().subscribe({next: (res) => {this.lessons = res;
    console.log(this.lessons)}})
  }

  openLesson(id: number) {
    this.router.navigate([`/lesson/${id}`]);
  }
}
