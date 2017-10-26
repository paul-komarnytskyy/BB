import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class CategoriesService {

    private basePath: string;

    constructor(private http: Http, private authenticationService: AuthenticationService) {
        this.basePath = 'http://localhost:55202';
    }

    getCategories() : Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/values/list', requestOptions);
        return observable;
    }

    getCategories2(): Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/values/list2', requestOptions);
        return observable;
    }

    getCategories3(): Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/values/list3', requestOptions);
        return observable;
    }

    getCategory(): Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);
        
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/values/value?id=5', requestOptions);
        return observable;
    }
}