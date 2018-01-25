import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

import { BaseRequestService } from './base-request.service';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class CharacteristicsService extends BaseRequestService {
    
    constructor(http: Http, private authenticationService: AuthenticationService) {
        super(http);
    }

    GetCharacteristics(categoryID: number) : Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/characteristics/getCharsForCategory?categoryId=' + categoryID, requestOptions);
        return observable;
    }
}