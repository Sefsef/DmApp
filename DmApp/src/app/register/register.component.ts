import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {

  registerUserData = {};

  constructor(private auth: AuthService, private router: Router) { }

  ngOnInit() {
  }

  register() {
    this.auth.register(this.registerUserData).subscribe(
      res => 
      {
        console.log(res);
        this.router.navigate(['/home']);
        //localStorage.setItem('token', (res as any).token)
      },
      error => console.log(error),
      () => {
        // redirect to home
      }
    )
  }
}