import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class DetailsService {

    private basePath: string;

    constructor(private http: Http, private authenticationService: AuthenticationService) {
        this.basePath = 'http://localhost:55202';
    }

    getProductById(Id: number): Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/products/GetProductById/' + Id, requestOptions);
        return observable;
    }
}