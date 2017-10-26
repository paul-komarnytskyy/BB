import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import { UserService } from './user.service';
import 'rxjs/add/operator/map'
import { User } from '../Model/Users/User';

@Injectable()
export class AuthenticationService {

    public token: string;
    private basePath: string;
    private userService: UserService;

    constructor(private http: Http, ) {
        this.basePath = 'http://localhost:55202';
        this.userService = new UserService();

        // set token if saved in local storage
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser != null) {
            this.userService.CurrentUser = currentUser;
            this.token = currentUser.token.access_token;
        }
    }

    login(username: string, password: string) : Observable<Response> {

        let headers = new Headers();

        //append content-type to headers
        headers.append('Content-type', 'application/x-www-form-urlencoded');

        //check if localStorage contains token. If yes, append authorization to headers
        let currentUser = localStorage.getItem('currentUser');
        if (currentUser !== '[object Object]' && currentUser !== null) {
            //headers.append('Authorization', 'Bearer' + ' ' + currentUser.token);
        }

        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.post(this.basePath + '/token',
            "username=" + username + "&password=" + password + "&grant_type=password",
            requestOptions);
        return observable;
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('currentUser');
    }
}