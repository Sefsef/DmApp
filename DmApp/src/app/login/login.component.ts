import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {

  loginUserData = {};

  constructor(private auth: AuthService) { }

  ngOnInit() {
  }

  login() {
    this.auth.login(this.loginUserData).subscribe(
      response => 
      {
        console.log(response);
        localStorage.setItem('token', (response as any).token);
      },
      error => console.log(error)
    )
  }

}
