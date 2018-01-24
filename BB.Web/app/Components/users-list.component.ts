import { Component, OnInit } from '@angular/core';
import { UserListService } from '../Services/user-list.service'
import { Option } from '../Model/Users/Option'
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    moduleId: module.id,
    selector: 'user-list',
    templateUrl: './users-list.html',
})

export class UsersListComponent implements OnInit {
    public users: any[];
    options = [
        new Option(0, 'none'),
        new Option(1, 'VIP'),
        new Option(2, 'loyal'),
    ];
    constructor(private productsService: UserListService, private router: Router) {

    }

    ngOnInit() {
        this.productsService.getUsers().map((response) => response.json())
            .subscribe((data) => {
                this.users = [];
                console.log(data);
                for (var user of data.Users) {
                    console.log(user);
                    this.users.push(user);
                }
            });
    }

    setDiscount(discountId: number, userId: number)
    {
        console.log(discountId, userId);
        this.productsService.promoteUser( userId, discountId).map((response) => response.json())
            .subscribe((data) => {
                this.productsService.getUsers().map((response) => response.json())
                    .subscribe((data1) => {
                        this.users = [];
                        console.log(data1);
                        for (var user of data1.Users) {
                            console.log(user);
                            this.users.push(user);
                        }
                    });
            });
    }
}
