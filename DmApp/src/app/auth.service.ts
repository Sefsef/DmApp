import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  loginURL: string = "http://localhost:4000/users/authenticate"; 
  registerURL: string = "http://localhost:4000/users/register";

  constructor(private http: HttpClient) { }

  login(loginUserData) {
    return this.http.post(this.loginURL, loginUserData);
  }

  register(registerUserData) {
    return this.http.post(this.registerURL, registerUserData);
  }

  logout() {
    localStorage.removeItem('token');
  }

  loggedIn() {
    return !!localStorage.getItem('token');
  }

  getToken() {
    return localStorage.getItem('token');
  }
}
