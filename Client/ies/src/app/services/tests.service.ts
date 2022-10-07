import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Test } from '../models/test';
import { TestResult } from '../models/test-result';

@Injectable({
  providedIn: 'root'
})
export class TestsService {
  url: string = "";
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  generateTest(startingChapterId: number, endingChapterId: number) {
    this.url = environment.serverUrl + `/Tests/Generate`;
    return this.http.get<Test>(this.url, { params: new HttpParams().set("startingChapterId", startingChapterId).set("endingChapterId", endingChapterId) });
  }

  submitResult(result: TestResult) {
    this.url = environment.serverUrl + "/Tests/SubmitResult";
    return this.http.post(this.url, result);
  }
}
