import { Component, OnInit } from '@angular/core';
import { UserService } from '../Services/user.service'
import { AuthenticationService } from '../Services/authentication.service'
import { User } from '../Model/Users/User';

@Component({
    selector: 'admin-component',
    templateUrl: 'app/Components/admin.html',
})
export class AdminComponent {
    users: User[];

    constructor(private userService: UserService, private authenticationService: AuthenticationService) {
        this.users = [];
    }

    ngOnInit() {
        this.authenticationService.getUsers().map((response) => response.json())
            .subscribe((data) => {
                this.users.length = 0;
                for (var user of data) {
                    this.users.push(new User(user.Username, user.Roles, user.Email, user.UserID, user.LoyaltyStatus));
                }
            });
    }
}
