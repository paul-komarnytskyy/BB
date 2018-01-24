import { Component } from '@angular/core';
import { AuthenticationService } from '../Services/authentication.service'


@Component({
    moduleId: module.id,
    selector: 'navbar',
    templateUrl: './navbar.html',
})

export class NavbarComponent {

    private isAuthenticated: boolean;
    private isAdmin: boolean;

    constructor(private authenticationService: AuthenticationService) {
        this.isAdmin = false;
    }

    public statusChanged(isAuthenticated: boolean) {
        this.isAdmin = false;
        this.isAuthenticated = isAuthenticated;
        if (!this.isAuthenticated) {
            this.isAdmin = false;
        }
        console.log(this.authenticationService.userID);
        console.log(isAuthenticated);
    }
    public adminAuth(isAdmin: boolean) {
        this.isAdmin = isAdmin;
    }
    
}
