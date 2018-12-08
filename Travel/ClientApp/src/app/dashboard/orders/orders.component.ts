import { Component, OnInit } from '@angular/core';
import { ConfigService } from '../../shared/services/ConfigService';
import { Http } from '@angular/http';
import '../../rxjs-operators'
import { DashboardService } from '../services/dashboard.service'

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  baseUrl: string = '';
  orders: iorder;

  constructor(private http: Http, private configService: ConfigService, private dashboardService: DashboardService) {
    this.baseUrl = configService.getApiURI();
  }

  ngOnInit() {
    this.dashboardService.getOrdersData().subscribe((result: iorder) => {
      this.orders = result;
    }, error => console.error(error));
  }

  onDelete(order: number) {
    this.dashboardService.deleteOrderData(order).subscribe((result) => {
      console.log(result);
    }, error => console.error(error));
  }
  onUpdate(order) {

  }
}

interface iorder {
  id: number;
  clientId: number;
  voucherId: number;
  status: number;
  beginDate: string;
  endDate: string;
}

