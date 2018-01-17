import { Injectable } from '@angular/core';

import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class OrdersService {

    private basePath: string;

    constructor(private http: Http, private authenticationService: AuthenticationService) {
        this.basePath = 'http://localhost:55202';
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

        var observable = this.http.post(this.basePath + '/api/Orders/addItemToOrder?userId=' + userId + '&productId=' + productId, requestOptions);
        return observable;
    }
}