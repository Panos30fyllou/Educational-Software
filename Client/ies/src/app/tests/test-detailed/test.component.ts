import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { combineLatest, Subscription } from 'rxjs';
import { Chapter } from 'src/app/models/chapter';
import { Profile } from 'src/app/models/profile';
import { Question } from 'src/app/models/question';
import { Test } from 'src/app/models/test';
import { TestResult } from 'src/app/models/test-result';
import { AuthService } from 'src/app/services/auth.service';
import { LessonsService } from 'src/app/services/lessons.service';
import { TestsService } from 'src/app/services/tests.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  profile?: Profile
  chapters: Chapter[] = []
  startingChapterId = 0
  endingChapterId = 0
  question?: Question;
  public test: Test;
  public routeSub?: Subscription;
  index = 0
  userAnswerIds: number[] = []
  constructor(private route: ActivatedRoute, private testsService: TestsService, private authSrv: AuthService, private lessonsSrv: LessonsService, public snackBar: MatSnackBar) {
    this.test = new Test();
  }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.question = this.test.questions[0]
      this.startingChapterId = parseInt(params['startingChapterId']);
      this.endingChapterId = parseInt(params['endingChapterId']);

      combineLatest([
        this.lessonsSrv.getChapters(),
        this.testsService.generateTest(this.startingChapterId, this.endingChapterId),
        this.authSrv.getCurrentUserProfile()]
      ).subscribe(([chapters, test, profile]) => {
        this.chapters = chapters
        this.test = test;
        this.question = this.test.questions[0];
        this.profile = profile;
      });
    });
  }

  ngOnDestroy() {
    this.routeSub?.unsubscribe();
  }

  submitAnswers() {
    let res = new TestResult();
    res.startingChapterId = this.startingChapterId;
    res.endingChapterId = this.endingChapterId;
    res.studentId = this.profile?.roleId ?? 0
    res.score = 0
    for (let i = 0; i < this.userAnswerIds.length; i++) {
      if (this.userAnswerIds[i] === this.test.questions[i].correctAnswerId)
        res.score = res.score + this.test.questions[i].points
      else
        res.wrongQuestionIds.push(this.userAnswerIds[i])
    }
    debugger
    this.testsService.submitResult(res).subscribe({
      next: () => {
        if (res.wrongQuestionIds.length < 1)
          this.snackBar.open("Score: " + res.score + " Good job!", "OK", { duration: 5000 });
        else
          this.snackBar.open(
            "Score: " + res.score + " You should revise chapters: " +
            this.chapters.find(c => c.chapterId === this.startingChapterId)?.name +
            " - " +
            this.chapters.find(c => c.chapterId === this.endingChapterId)?.name, "OK", { duration: 10000 });
      }
    });
  }

  goToQuestion(increment: number) {
    if (this.index + increment > -1 && this.index + increment < this.test.questions.length) {
      this.index = this.index + increment;
      this.question = this.test.questions[this.index]
    }
  }
}
