import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Test } from '../models/test';


@Injectable({
  providedIn: 'root'
})
export class TestsService {
  url: string = "";
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  // getTestListItems(): Observable<TestListItem[]> {
  //   this.url = environment.serverUrl + "/Tests/SelectListItems";
  //   return this.http.get<TestListItem[]>(this.url);
  // }

  // getTestById(id: number): Observable<Test> {
  //   this.url = environment.serverUrl + `/Tests/SelectById/${id}`;
  //   return this.http.get<Test>(this.url);
  // }

  generateTest(chapterId: number){
    this.url = environment.serverUrl + `/Tests/GenerateTest/${chapterId}`;
    return this.http.get<Test>(this.url);
  }
}
