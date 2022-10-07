import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { LessonListItem } from '../models/lesson-list-item';
import { Lesson } from '../models/lesson';
import { Chapter } from '../models/chapter';
import { StudentLessonProgress } from '../models/student-lesson-progress';

@Injectable({
  providedIn: 'root'
})
export class LessonsService {
  url: string = "";
  lessonIds: number[] = []
  private lessons: BehaviorSubject<LessonListItem[]> = new BehaviorSubject<LessonListItem[]>([]);
  private lessonIdsList: BehaviorSubject<number[]> = new BehaviorSubject<number[]>([]);
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {
    this.getLessonListItems().subscribe({
      next: (lessons) => {
        this.lessons.next(lessons)
        this.lessonIds = []
        lessons.forEach(lesson => {
          this.lessonIds.push(lesson.lessonId)
        });
        this.lessonIdsList.next(this.lessonIds);
      }
    });
  }

  get getLessonIds$() {
    return this.lessonIdsList.asObservable();
  }

  get getLessons$() {
    return this.lessons.asObservable();
  }

  getLessonListItems(): Observable<LessonListItem[]> {
    this.url = environment.serverUrl + "/Lessons/SelectListItems";
    return this.http.get<LessonListItem[]>(this.url);
  }

  getLessonById(id: number): Observable<Lesson> {
    this.url = environment.serverUrl + `/Lessons/SelectById`;
    return this.http.get<Lesson>(this.url, { params: new HttpParams().set("id", id) });
  }

  getChapters(): Observable<Chapter[]> {
    this.url = environment.serverUrl + "/Lessons/GetAllChapters";
    return this.http.get<Chapter[]>(this.url);
  }

  completeLesson(progress: StudentLessonProgress) {
    this.url = environment.serverUrl + "/Students/CompletedLesson";
    return this.http.post(this.url, progress);
  }

  getLessonProgress(lessonId: number, studentId: number) {
    this.url = environment.serverUrl + "/Lessons/GetLessonProgress";
    return this.http.get<StudentLessonProgress>(this.url, { params: new HttpParams().set("lessonId", lessonId).set("studentId", studentId) });
  }
}
