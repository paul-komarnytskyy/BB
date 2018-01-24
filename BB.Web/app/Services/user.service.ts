import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

import { User } from '../Model/Users/user';

@Injectable()
export class UserService {
    public CurrentUser: any;
}