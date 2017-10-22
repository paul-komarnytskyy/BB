import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class CategoriesService {

    public token: string;
    private basePath: string;

    constructor(private http: Http, private authenticationService: AuthenticationService) {
        this.basePath = 'http://localhost:55202';
        // set token if saved in local storage

        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser != null) {
            this.token = currentUser.token;
        }
    }

    getCategories() : Observable<Response> {

        let headers = new Headers();

        //append content-type to headers
        headers.append('Content-type', 'application/x-www-form-urlencoded');
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/categories/list', requestOptions);
        return observable;
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('currentUser');
    }
}