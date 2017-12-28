import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../Services/authentication.service'

@Component({
    moduleId: module.id,
    selector: 'register',
    templateUrl: './register.html',
})

export class RegisterComponent {

    private username: string;
    private password: string;
    private confirmPassword: string;
    private email: string;
    private confirmEmail: string;
    private errorMessage: string;

    constructor(private authenticationService: AuthenticationService) {
        this.username = '';
        this.password = '';
        this.confirmPassword = '';
        this.email = '';
        this.confirmEmail = '';
        this.errorMessage = '';
    }

    public register() {
        console.log('registering started');

        if (this.username.trim() == '') {
            this.errorMessage = "Username field can't be empty.";
            console.log(this.errorMessage);
            return;
        }

        if (this.email.trim() == '') {
            this.errorMessage = "Email field can't be empty.";
            console.log(this.errorMessage);
            return;
        }

        if (this.password.trim() == '') {
            this.errorMessage = "Password field can't be empty.";
            console.log(this.errorMessage);
            return;
        }

        if (this.password != this.confirmPassword) {
            this.errorMessage = "Passwords do not match.";
            console.log(this.errorMessage);
            return;
        }

        if (this.email != this.confirmEmail) {
            this.errorMessage = "Emails do not match.";
            console.log(this.errorMessage);
            return;
        }

        this.authenticationService.register(this.username, this.password, this.email)
            .subscribe((res) => {
                var resCode = res.json();
                if (resCode == 1) {
                    console.log("good");
                }
                else if (resCode == 0) {
                    console.log("bad");
                }
                else {
                    console.log("very bad");
                }
            },
            (err) => {},
            () => {
            });
    }
}
