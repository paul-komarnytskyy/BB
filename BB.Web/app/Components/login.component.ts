import { Component } from '@angular/core';
import { User } from '../Model/Users/User';
import { Router } from '@angular/router'

@Component({
    selector: 'login',
    templateUrl: 'app/Components/login.html',
})

export class LoginComponent {
    user: User;
    router: Router;

    constructor(router: Router) {
        this.router = router;
        var username = localStorage.getItem("currentUser");
        if (username != null) {
            this.user = new User(username, null, "pkom@gmail.com", 1);
        }
    }

    login() {
        this.user = new User("Polus", null, "pkom@gmail.com", 1);
        localStorage.setItem("currentUser", this.user.toString());
    }

    logout() {
        this.user = null;
        localStorage.removeItem("currentUser");
        this.router.navigateByUrl('/home');
    }
}
