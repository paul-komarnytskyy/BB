import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';

import { AuthenticationService } from './authentication.service';
import { BaseRequestService } from './base-request.service';

import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class OrdersService extends BaseRequestService{
    
    constructor(http: Http, private authenticationService: AuthenticationService) {
        super(http);
    }

    getOrders(): Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);
        
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/orders/list?userId='+this.authenticationService.userID, requestOptions);
        return observable;
    }

    getOrder(orderID : number): Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);
        
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/orders/order?id=' + orderID, requestOptions);
        return observable;
    }

    getCart(): Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);
        
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/orders/getCart?userId=' + this.authenticationService.userID, requestOptions);
        return observable;
    }

    getCartForUser(userID: number): Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);
        
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.get(this.basePath + '/api/orders/getCart?userId=' + userID, requestOptions);
        return observable;
    }

    addItemToOrder(userId: number, productId: number): Observable<Response> {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', 'Bearer ' + this.authenticationService.token);
        
        let requestOptions = new RequestOptions({ headers: headers });

        var observable = this.http.post(this.basePath + '/api/orders/addItemToOrder?userId=' + userId + '&productId=' + productId, requestOptions);
        return observable;
    }
}