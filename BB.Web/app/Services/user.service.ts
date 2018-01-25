import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

import { User } from '../Model/Users/User';
import { BaseRequestService } from './base-request.service';

@Injectable()
export class UserService extends BaseRequestService {
    public CurrentUser: any;

    public userID: number;
    private userService: UserService;

    constructor(http: Http) {
        super(http);
    }
}