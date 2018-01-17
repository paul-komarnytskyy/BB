import { Component, OnInit } from '@angular/core';
import { UserService } from '../Services/user.service';
import { AuthenticationService } from '../Services/authentication.service';
import { AdminService } from '../Services/admin.service';
import { User } from '../Model/Users/User';


@Component({
    selector: 'admin-component',
    templateUrl: 'app/Components/admin.html',
})
export class AdminComponent {
    users: User[];

    constructor(private userService: UserService, private authenticationService: AuthenticationService, private adminService: AdminService) {
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

    setLoyaltyStatus(userID: number, loyaltyLevel: number) {
        this.adminService.setLoyaltyStatus(userID, loyaltyLevel).map(r => r.json()).subscribe(data =>
        {
            var index = this.users.findIndex(u => u.UserID == data.UserID);
            if (index > -1) {
                this.users[index] = new User(data.Username, data.Roles, data.Email, data.UserID, data.LoyaltyStatus);
            }
        });
    }
}
