import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Lesson } from 'src/app/models/lesson';
import { LessonsService } from 'src/app/services/lessons.service';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.scss']
})
export class LessonComponent implements OnInit {

  public lesson: Lesson;
  public routeSub?: Subscription;
  constructor(private route: ActivatedRoute, private lessonsService: LessonsService) {
    this.lesson = new Lesson();
  }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.lessonsService.getLessonById(params['id']).subscribe({ next: (lesson) => this.lesson = lesson })
    });
  }

  ngOnDestroy() {
    this.routeSub?.unsubscribe();
  }
}
