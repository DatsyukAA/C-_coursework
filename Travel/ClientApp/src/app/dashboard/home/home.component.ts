import { Component, OnInit } from '@angular/core';
import { ConfigService } from '../../shared/services/ConfigService';
import { Http } from '@angular/http';
import '../../rxjs-operators'
import { DashboardService } from '../services/dashboard.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  baseUrl: string = '';
  somes: myint;

  constructor(private http: Http, private configService: ConfigService, private dashboardService: DashboardService) {
    this.baseUrl = configService.getApiURI();
  }

  ngOnInit() {

    this.dashboardService.getUserData().subscribe((result: myint) => {
      console.log("RESULT");
      console.log(result);
      console.log("RESULT");
      this.somes = result;
    }, error => console.error(error));
  }
}

interface myint {
  id: number;
  email: string;
  password: string;
  firstName: string;
  lastName: string;
  role: string;
  auth_token: string;
}
