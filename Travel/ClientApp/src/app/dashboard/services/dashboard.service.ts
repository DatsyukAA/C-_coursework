import { Injectable } from '@angular/core';
import { ConfigService } from '../../shared/services/ConfigService';
import { Http, Headers, RequestOptions } from '@angular/http';
import '../../rxjs-operators';
import { Observable } from 'rxjs';
import { iorder } from '../../shared/models/IOrder';

@Injectable()
export class DashboardService {
  private baseUrl: string;
  constructor(private http: Http, private configService: ConfigService) {
    this.baseUrl = configService.getApiURI();
  }
  getOrdersData() {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', 'Bearer ' + authToken);
    let options = new RequestOptions({ headers: headers });
    return this.http.get(this.baseUrl + '/Orders/getOrderData', options).map(res => res.json());
  }
  deleteOrderData(order: number)
  {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', 'Bearer ' + authToken);
    let options = new RequestOptions({ headers: headers, body: order });
    return this.http.delete(this.baseUrl + '/Orders/deleteOrderData', options).map(res => res.json());
  }
}
