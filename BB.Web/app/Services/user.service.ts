import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'
import { User } from '../Model/Users/User';

@Injectable()
export class UserService {
    public CurrentUser: any;

    public userID: number;
    private basePath: string;
    private pythonPath: string;
    private userService: UserService;

    constructor(private http: Http) {
        this.basePath = 'http://localhost:55202';
        this.pythonPath = 'http://localhost:55202';
    }
}