import { Component, OnInit } from '@angular/core';
import { ConfigService } from '../../shared/services/ConfigService';
import { Http } from '@angular/http';
import '../../rxjs-operators';
import { DashboardService } from '../services/dashboard.service';
import { iorder } from '../../shared/models/interfacesmodels';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  baseUrl: string = '';
  orders: iorder[];
  updateinfo: iorder;
  status = true;

  constructor(private http: Http, private configService: ConfigService, private dashboardService: DashboardService) {
    this.baseUrl = configService.getApiURI();
  }

  ngOnInit() {
    this.dashboardService.getOrdersData().subscribe((result: iorder[]) => {
      this.orders = result;
    }, error => console.error(error));
  }

  onDelete(order: number) {
    this.dashboardService.deleteOrderData(order).subscribe((result) => {
    }, error => console.error(error));
    this.dashboardService.getOrdersData().subscribe((result: iorder[]) => {
      this.orders = result;
    }, error => console.error(error));
  }

  onUpdate(order) {
    this.updateinfo = order;
    this.status = false;
  }

  onUpdateForm(clientId, voucherId, status: number, beginDate, endDate: string) {
    this.updateinfo.clientId = clientId;
    this.updateinfo.voucherId = voucherId;
    this.updateinfo.status = status;
    this.updateinfo.beginDate = beginDate;
    this.updateinfo.endDate = endDate;
    console.log(this.updateinfo);
    this.dashboardService.updateOrderData(this.updateinfo).subscribe(() => {
      this.status = true;
      this.dashboardService.getOrdersData().subscribe((result: iorder[]) => {
        this.orders = result;
      }, error => console.error(error));

    });
  }
  back() {
    this.status = true;
  }
}

