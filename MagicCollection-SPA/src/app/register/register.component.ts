import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../Services/auth.service';
import { AlertifyService } from '../Services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
    @Input() booksFromHome: any;
    @Output() cancelRegistration = new EventEmitter();

    model: any = {};

    constructor(private authService: AuthService, private alertify: AlertifyService) { }

    ngOnInit() {
    }

    register() {
        this.authService.register(this.model).subscribe(() => {
            this.alertify.success('Registration successful');
        },
        error => {
         this.alertify.error(error);
        });
    }

    cancel() {
        this.cancelRegistration.emit(false);
    }
}
