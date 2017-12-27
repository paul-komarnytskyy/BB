import { Component } from '@angular/core';
@Component({
    moduleId: module.id,
    selector: 'navbar',
    templateUrl: './navbar.html',
})

export class NavbarComponent {

    private isAuthenticated: boolean;

    constructor() {
    }

    public statusChanged(isAuthenticated: boolean) {
        this.isAuthenticated = isAuthenticated;
        console.log(isAuthenticated);
    }
}
