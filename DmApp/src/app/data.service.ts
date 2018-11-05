import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  private testlink: string = 
    "http://localhost:63581/api/spells/byName/test";

  getUsers() {
    return this.http.get(this.testlink);
  }
}
