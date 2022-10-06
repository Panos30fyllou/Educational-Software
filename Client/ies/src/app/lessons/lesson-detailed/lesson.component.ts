import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { combineLatest, Subscription } from 'rxjs';
import { Lesson } from 'src/app/models/lesson';
import { LessonsService } from 'src/app/services/lessons.service';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.scss']
})
export class LessonComponent implements OnInit {
  currentIndex = 0
  currentLessonId = 0;
  lessonIds: number[] = []
  public lesson: Lesson;
  public routeSub?: Subscription;
  constructor(private route: ActivatedRoute, private lessonsSrv: LessonsService, private router: Router) {
    this.lesson = new Lesson();
  }

  ngOnInit() {
    combineLatest([
      this.route.params,
      this.lessonsSrv.getLessonIds$]
    ).subscribe(([params, lessonIds]) => {
      this.currentLessonId = parseInt(params['id']);
      this.lessonIds = lessonIds;
      this.currentIndex = this.lessonIds.indexOf(this.currentLessonId);
      this.lessonsSrv.getLessonById(this.currentLessonId).subscribe({
        next: (lesson) => {
          this.lesson = lesson;
        },
        error: () => { this.router.navigate([`/lessons`]) }
      });
    });
  }

  ngOnDestroy() {
  }

  goToLesson(index: number): void {
    if (this.currentIndex + index > -1 && this.currentIndex + index < this.lessonIds.length) {
      this.currentIndex = this.currentIndex + index
      this.router.navigate([`/lesson/${this.lessonIds[this.currentIndex]}`]);
    }

    // this.lessonsService.getLessonById(this.currentLessonId).subscribe({
    //   next: (lesson) => {
    //     this.lesson = lesson;
    //   }
    // });
  }
}
