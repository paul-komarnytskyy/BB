import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import { UserService } from './user.service';
import 'rxjs/add/operator/map'
import { User } from '../Model/Users/User';
import { RegistrationModel } from "../Model/Users/RegistrationModel";

@Injectable()
export class AuthenticationService {

    public token: string;
    public userID: number;
    public isAdmin: boolean;
    private basePath: string;
    private pythonPath: string;

    constructor(private http: Http, private userService: UserService) {
        this.basePath = 'http://localhost:55202';
        this.pythonPath = 'http://localhost:55202';

        // set token if saved in local storage
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser != null) {
            this.userService.CurrentUser = currentUser;
            this.token = currentUser.token.access_token;
            this.getUserID();
        }
    }

    login(username: string, password: string) : Observable<Response> {

        let headers = new Headers();

        //append content-type to headers
        headers.append('Content-type', 'application/x-www-form-urlencoded');
        headers.append('Access-Control-Allow-Origin', '*');

        //check if localStorage contains token. If yes, append authorization to headers
        let currentUser = localStorage.getItem('currentUser');
        if (currentUser !== '[object Object]' && currentUser !== null) {
            //headers.append('Authorization', 'Bearer' + ' ' + currentUser.token);
        }

        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.post(this.basePath + '/token',
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

    getUserID(): void {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.token);
        headers.append('Access-Control-Allow-Origin', '*');

        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/users/getID', requestOptions);
        observable.map(response => response.json()).subscribe(ID => {
            this.userID = ID;
            //this.setAdmin();
        });
    }

    getRoles(id: number): any {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.token);
        headers.append('Access-Control-Allow-Origin', '*');
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/users/getRoles?userID=' + id, requestOptions);
        return observable;
    }

    getUsers(): Observable<Response> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.token);
        headers.append('Access-Control-Allow-Origin', '*');
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/users/getUsers', requestOptions);
        return observable;
    }

    setAdmin(): void {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.token);
        headers.append('Access-Control-Allow-Origin', '*');
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/users/IsAdmin?userID=' + this.userID, requestOptions);
        observable.map(response => response.json()).subscribe(isAdmin => this.isAdmin = isAdmin);
    }

    register(username: string, password: string, email: string) : Observable<Response> {

        let headers = new Headers();

        //append content-type to headers
        headers.append('Content-type', 'application/x-www-form-urlencoded');
        headers.append('Access-Control-Allow-Origin', '*');

        let requestOptions = new RequestOptions({ headers: headers });
        var registrationModel = new RegistrationModel(email, username, password);
        var body = JSON.stringify(registrationModel);
        var observable = this.http.get(this.basePath + '/api/users/register?username=' + username + '&password=' + password + '&email=' + email, requestOptions);
        return observable;
    }
}