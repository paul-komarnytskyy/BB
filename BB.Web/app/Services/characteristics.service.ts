import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class CharacteristicsService {

    private basePath: string;

    constructor(private http: Http) {
        this.basePath = 'http://localhost:55202';
    }

    GetCharacteristics(categoryID: number) : Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/characteristics/category?id=' + categoryID, requestOptions);
        return observable;
    }
}