import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class BaseRequestService {
    protected basePath: string;
    protected pythonPath: string;

    constructor(protected http: Http) {

        //.NET WebApi
        this.basePath = 'http://localhost:55202';

        //Python
        //this.basePath = 'http://localhost:55202';
    }
}

