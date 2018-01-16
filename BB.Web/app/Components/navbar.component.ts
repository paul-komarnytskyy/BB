import { Component } from '@angular/core';
//import { ModalService } from '../Services/modal.service';

@Component({
    moduleId: module.id,
    selector: 'navbar',
    templateUrl: './navbar.html',
})

export class NavbarComponent {

    private isAuthenticated: boolean;
    private isAdmin: boolean;
    private userID: any;

    //private cartID: string;

    constructor(/*private modalService : ModalService*/) {
        this.isAdmin = false;
        this.isAuthenticated = false;
        //this.cartID = 'cart';
    }

    public statusChanged(object: any) {
        this.isAuthenticated = object.isAuthenticated;
        this.isAdmin = object.isAdmin;
        this.userID = object.userID;
    }

    //public showCart() {
    //    if (this.userID != null && this.userID > 0 && this.isAuthenticated) {
    //        this.modalService.open(this.cartID);
    //    }
    //}
}
