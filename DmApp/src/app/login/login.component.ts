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
  errorMessage: string;

  constructor(private auth: AuthService, private router: Router) { }

  ngOnInit() {

  }

  login() {
    this.errorMessage = "test";
    this.auth.login(this.loginUserData).subscribe(
      response => 
      {
        console.log(response);
        localStorage.setItem('token', (response as any).token);
        this.router.navigateByUrl('/home');
      },
      error => {
        console.log(error.statusText);
        if (error.status == 0)
          this.errorMessage = "The server is currently not available.";
        else 
          this.errorMessage = error.statusText;
      }
    )
  }

}
