import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';

import { AuthenticationService } from './authentication.service';
import { BaseRequestService } from './base-request.service';

import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class CategoriesService  extends BaseRequestService {

    constructor(http: Http, private authenticationService: AuthenticationService) {
        super(http);
    }

    getCategories() : Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/categories/getCategories', requestOptions);
        return observable;
    }
}