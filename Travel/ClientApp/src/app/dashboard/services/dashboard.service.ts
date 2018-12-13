import { Injectable } from '@angular/core';
import { ConfigService } from '../../shared/services/ConfigService';
import { Http, Headers, RequestOptions } from '@angular/http';
import '../../rxjs-operators';
import { Observable } from 'rxjs';
import { searchdata, iorder } from '../../shared/models/interfacesmodels';

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
    return this.http.get(this.baseUrl + '/Admins/getOrderData', options).map(res => res.json());
  }
  deleteOrderData(order: number)
  {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', 'Bearer ' + authToken);
    let options = new RequestOptions({ headers: headers, body: order });
    return this.http.delete(this.baseUrl + '/Admins/deleteOrderData', options).map(res => res.json());
  }

  getVoucherData() {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', 'Bearer ' + authToken);
    let options = new RequestOptions({ headers: headers });
    return this.http.get(this.baseUrl + '/Operators/getVoucherData', options).map(res => res.json());
  }
  changeVoucherStatus(voucher: number) {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', 'Bearer ' + authToken);
    let options = new RequestOptions({ headers: headers });
    return this.http.put(this.baseUrl + '/Operators/changeVoucherStatus',voucher, options).map(res => res.json());
  }
  sendReport(report: string) {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', 'Bearer ' + authToken);
    let options = new RequestOptions({ headers: headers });
    return this.http.put(this.baseUrl + '/Operators/sendReport', JSON.stringify(report), options).map(res => res.json());
  }

  getSearchResult(resortId: number) {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', 'Bearer ' + authToken);
    let options = new RequestOptions({ headers: headers, body: resortId });
    return this.http.get(this.baseUrl + '/Clients/getSearchResult', options).map(res => res.json());
  }

  makeAnOrder(orderData: searchdata){
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', 'Bearer ' + authToken);
    let options = new RequestOptions({ headers: headers });
    return this.http.post(this.baseUrl + '/Operators/makeAnOrder', JSON.stringify(orderData), options).map(res => res.json());
  }

  getToursData(){
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', 'Bearer ' + authToken);
    let options = new RequestOptions({ headers: headers });
    return this.http.get(this.baseUrl + '/Clients/getToursData', options).map(res => res.json());
  }
}
