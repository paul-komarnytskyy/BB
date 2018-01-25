import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

import { BaseRequestService } from './base-request.service';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class AdminService extends BaseRequestService {

    constructor(http: Http, private authenticationService: AuthenticationService) {
        super(http);
    }

    setLoyaltyStatus(userID: number, loyaltyStatus: number): Observable<Response> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);

        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/admin/setLoyaltyStatus?userID=' + userID + '&loyaltyStatus=' + loyaltyStatus, requestOptions);
        observable.map(response => response.json()).subscribe(ID => {
            console.log('ok')
        });

        return observable;
    }
}