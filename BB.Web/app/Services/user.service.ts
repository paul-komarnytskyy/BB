import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map'

import { User } from '../Model/Users/user';

@Injectable()
export class UserService {
    public CurrentUser : any;
}