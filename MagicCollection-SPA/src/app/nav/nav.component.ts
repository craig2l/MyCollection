import { HomeComponent } from './../home/home.component';
import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../Services/alertify.service';
import { AuthService } from './../Services/auth.service';
import { Router } from '../../../node_modules/@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
    model: any = {};

    constructor(public authService: AuthService, private alertify: AlertifyService, 
        private router: Router) { }

    ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(
        next => {
            this.alertify.success('Logged in successfully');
        },
        error => {
            this.alertify.error(error);
        },
        () => {
            this.router.navigate(['/assetlist']);
        });
    }

    loggedIn() {
       return this.authService.loggedIn();
    }

    logout() {
        localStorage.removeItem('token');
        this.alertify.message('Logged out');
        this.router.navigate(['home']);
    }
}
