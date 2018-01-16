import { Component, ViewChild, Output, EventEmitter } from '@angular/core';
import { User } from '../Model/Users/User';
import { Router } from '@angular/router'
import { AuthenticationService } from '../Services/authentication.service'
import { UserService } from '../Services/user.service'


@Component({
    selector: 'login',
    templateUrl: 'app/Components/login.html',
})

export class LoginComponent {

    private username: string = '';
    private password: string = '';
    private isAuthenticated: boolean;
    private incorrectCredentials: boolean;
    private userID: number;

    @Output()
    statusChanged: EventEmitter<any> = new EventEmitter<any>();

    constructor(private router: Router, private authenticationService: AuthenticationService, private userService: UserService) {
        this.isAuthenticated = this.authenticationService.token != null;
        this.statusChanged.emit(this.isAuthenticated);
        this.incorrectCredentials = false;
    }

    login() {
        var name = this.username;
        this.authenticationService.login(name, this.password)
            .subscribe((res) => {
                var token = res.json();
                if (token) {
                    // set token property
                    this.authenticationService.token = token.access_token;

                    // store username and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify({ username: name, token: token }));

                    this.userService.CurrentUser = new User(name, null, null, null, 0);
                    // return true to indicate successful login
                    this.isAuthenticated = this.authenticationService.token != null;
                    this.username = '';
                    this.password = '';
                    this.authenticationService.getUserID().map(response => response.json()).subscribe(ID => {
                        this.userID = ID;
                        var emittedObject = { isAuthenticated: this.isAuthenticated, isAdmin: this.authenticationService.isAdmin, userID: ID }
                        this.statusChanged.emit(emittedObject);
                    });
                    this.incorrectCredentials = false;
                }
            },
            (err) => this.incorrectCredentials = true,
            () => { }
            );
    }

    logout() {
        this.authenticationService.logout();
        this.isAuthenticated = this.authenticationService.token != null;
        this.userID = this.isAuthenticated ? null : this.userID;
        var emittedObject = { isAuthenticated: this.isAuthenticated, isAdmin: this.authenticationService.isAdmin, userID: this.userID };
        this.statusChanged.emit(emittedObject);
        this.router.navigateByUrl('/home');
    }
}
