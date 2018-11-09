import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {

  loginUserData = {};

  constructor(private auth: AuthService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.auth.login(this.loginUserData).subscribe(
      response => 
      {
        console.log(response);
        localStorage.setItem('token', (response as any).token);
        this.router.navigateByUrl('/home');
      },
      error => console.log(error)
    )
  }

}
