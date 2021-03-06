﻿import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class BaseRequestService {
    protected basePath: string;
    protected pythonPath: string;
    protected apiPath: string;

    constructor(protected http: Http) {
        this.apiPath = 'http://localhost:55202';
        this.pythonPath = 'http://localhost:50040';

        this.basePath = this.pythonPath;
    }
}

