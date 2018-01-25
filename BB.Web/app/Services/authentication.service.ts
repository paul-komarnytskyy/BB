import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

import { RegistrationModel } from "../Model/Users/RegistrationModel";

import { UserService } from './user.service';
import { BaseRequestService } from './base-request.service';

@Injectable()
export class AuthenticationService extends BaseRequestService {

    public token: string;
    public userID: number;
    public isAdmin: boolean;

    private oauthBasePath: string;

    constructor(http: Http, private userService: UserService) {
        super(http);

        // set token if saved in local storage
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser != null) {
            this.userService.CurrentUser = currentUser;
            this.token = currentUser.token.access_token;
            this.getUserID();
        }
    }

    login(username: string, password: string): Observable<Response> {

        let headers = new Headers();

        //append content-type to headers
        headers.append('Content-type', 'application/x-www-form-urlencoded');


        //check if localStorage contains token. If yes, append authorization to headers
        let currentUser = localStorage.getItem('currentUser');
        if (currentUser !== '[object Object]' && currentUser !== null) {
            //headers.append('Authorization', 'Bearer' + ' ' + currentUser.token);
        }

        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.post(this.apiPath + '/token',
            "username=" + username + "&password=" + password + "&grant_type=password",
            requestOptions);
        this.isAdmin = username == "admin";
        observable.map(response => response.json()).subscribe(r => this.getUserID());
        return observable;
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('currentUser');
    }

    getUserID(): Observable<Response> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.token);


        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.apiPath + '/api/users/getID', requestOptions);
        observable.map(response => response.json()).subscribe(ID => {
            this.userID = ID;
            this.getUser();
        });

        return observable;
    }

    getUser(): void {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.token);


        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.apiPath + '/api/users/getUser?userId=' + this.userID, requestOptions);
        observable.map(response => response.json()).subscribe(user => {
            this.userService.CurrentUser = user;
        });
    }

    getRoles(id: number): any {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.token);
        
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.apiPath + '/api/users/getRoles?userID=' + id, requestOptions);
        return observable;
    }

    getUsers(): Observable<Response> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.token);
        
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.apiPath + '/api/users/getUsers', requestOptions);
        return observable;
    }

    setAdmin(): void {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.token);
        
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.apiPath + '/api/users/IsAdmin?userID=' + this.userID, requestOptions);
        observable.map(response => response.json()).subscribe(isAdmin => this.isAdmin = isAdmin);
    }

    register(username: string, password: string, email: string) : Observable<Response> {

        let headers = new Headers();

        //append content-type to headers
        headers.append('Content-type', 'application/x-www-form-urlencoded');
        

        let requestOptions = new RequestOptions({ headers: headers });
        var registrationModel = new RegistrationModel(email, username, password);
        var body = JSON.stringify(registrationModel);
        var observable = this.http.get(this.apiPath + '/api/users/register?username=' + username + '&password=' + password + '&email=' + email, requestOptions);
        return observable;
    }
}