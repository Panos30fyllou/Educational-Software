import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Profile } from '../models/profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  url: string = "";
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  updateProfile(profile: Observable<Profile>) {
    this.url = environment.serverUrl + "/Users/Update";
    return this.http.put<Profile>(this.url, profile);
  }

  getProgressById(id: number): Observable<number> {
    this.url = environment.serverUrl + `/Students/GetProgress`;
    return this.http.get<number>(this.url, { params: new HttpParams().set("id", id) });
  }

  getAverageTestScoreById(id: number): Observable<number> {
    this.url = environment.serverUrl + `/Students/GetAverageTestScore`;
    return this.http.get<number>(this.url, { params: new HttpParams().set("id", id) });
  }

  getHighScoreById(id: number): Observable<number> {
    this.url = environment.serverUrl + `/Students/GetHighScore`;
    return this.http.get<number>(this.url, { params: new HttpParams().set("id", id) });
  }
}
