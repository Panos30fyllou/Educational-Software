import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { LessonListItem } from '../models/lesson-list-item';

@Injectable({
  providedIn: 'root'
})
export class LessonsService {
  url: string = "";
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getLessonListItems(): Observable<LessonListItem[]> {
    this.url = environment.serverUrl + "/Lessons/SelectListItems";
    return this.http.get<LessonListItem[]>(this.url);
  }

  getLessonById(id: number) {
    this.url = environment.serverUrl + `/Lessons/SelectById/${id}`;
    return this.http.get(this.url);
  }
}
