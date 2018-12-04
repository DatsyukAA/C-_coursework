import { Injectable } from '@angular/core';
import { ConfigService } from '../../shared/services/ConfigService';
import { Http, Headers, RequestOptions } from '@angular/http';
import '../../rxjs-operators';
import { Observable } from 'rxjs';

@Injectable()
export class DashboardService {
  private baseUrl: string;
  constructor(private http: Http, private configService: ConfigService) {
    this.baseUrl = configService.getApiURI();
  }
  getUserData() {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', 'Bearer ' + authToken);
    let options = new RequestOptions({ headers: headers });
    console.log("ITS A HEADERS");
    console.log(headers);
    console.log("ITS A HEADERS");
    return this.http.get(this.baseUrl + '/SampleData/getUserData', options).map(res => res.json());
  }
}
