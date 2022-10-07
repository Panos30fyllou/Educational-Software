import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { combineLatest, Subscription } from 'rxjs';
import { Lesson } from 'src/app/models/lesson';
import { Profile } from 'src/app/models/profile';
import { StudentLessonProgress } from 'src/app/models/student-lesson-progress';
import { AuthService } from 'src/app/services/auth.service';
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
  public profile: Profile;
  public lesson: Lesson;
  progress: StudentLessonProgress = new StudentLessonProgress;
  public routeSub?: Subscription;
  constructor(private route: ActivatedRoute, private lessonsSrv: LessonsService, private router: Router, private authSrv: AuthService, private snackBar: MatSnackBar) {
    this.lesson = new Lesson();
    this.profile = new Profile();
  }

  ngOnInit() {
    combineLatest([
      this.route.params,
      this.lessonsSrv.getLessonIds$,
      this.authSrv.getCurrentUserProfile()]
    ).subscribe(([params, lessonIds, profile]) => {
      this.currentLessonId = parseInt(params['id']);
      this.lessonIds = lessonIds;
      this.currentIndex = this.lessonIds.indexOf(this.currentLessonId);
      this.profile = profile;

      this.lessonsSrv.getLessonById(this.currentLessonId).subscribe({
        next: (lesson) => this.lesson = lesson,
        error: () => { this.router.navigate([`/lessons`]) }
      });

      this.lessonsSrv.getLessonProgress(this.currentLessonId, profile.roleId).subscribe({
        next: (lessonProgress) => { this.progress = lessonProgress === null ? new StudentLessonProgress() : lessonProgress },
        error: () => this.progress = new StudentLessonProgress()
      }
      );
    });
  }

  changeLessonStatus() {
    this.progress.completed = !this.progress.completed;
    this.progress.dateCompleted = this.progress.completed ? new Date() : null;
    this.progress.lessonId = this.lesson.lessonId
    this.progress.studentId = this.profile.roleId;
    this.lessonsSrv.completeLesson(this.progress).subscribe({ next: () => { this.snackBar.open("Completed Lesson", "OK", { duration: 3000 }) } });
  }

  getChangeLessonStatusButtonText() {
    return this.progress.completed ? "Mark Uncompleted" : "Complete Lesson"
  }

  goToLesson(index: number): void {
    if (this.currentIndex + index > -1 && this.currentIndex + index < this.lessonIds.length) {
      this.currentIndex = this.currentIndex + index
      this.router.navigate([`/lesson/${this.lessonIds[this.currentIndex]}`]);
    }
  }
}
