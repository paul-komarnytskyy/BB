import { Component } from '@angular/core';
@Component({
    moduleId: module.id,
    selector: 'navbar',
    templateUrl: './navbar.html',
})

export class NavbarComponent {

    private isAuthenticated: boolean;
    private isAdmin: boolean;

    constructor() {
        this.isAdmin = false;
        this.isAuthenticated = false;
    }

    public statusChanged(object: any) {
        this.isAuthenticated = object.isAuthenticated;
        this.isAdmin = object.isAdmin;
        console.log(object.isAuthenticated);
        console.log(object.isAdmin);
    }
}
