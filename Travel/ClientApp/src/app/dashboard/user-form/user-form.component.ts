import { Component, OnInit } from '@angular/core';

import { DashboardService } from '../services/dashboard.service';
import { ivoucher, searchdata, itour } from '../../shared/models/interfacesmodels';
import { ConfigService } from '../../shared/services/ConfigService';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  baseUrl: string;
  resultVouchers: ivoucher[];
  tours: itour[];
  cn: string = "asfdgh";

  constructor(private dashboardService: DashboardService, private configService: ConfigService) {
    this.baseUrl = configService.getApiURI();
  }

  ngOnInit() {
    this.dashboardService.getToursData().subscribe((result: itour[]) =>
    {
      console.log(result);
      this.tours = result;
    });
  }

  getSearchResult(resortId: number)
  {
    this.dashboardService.getSearchResult(resortId).subscribe((result: ivoucher[]) =>
    {
      this.resultVouchers = result;
    });
  }

  makeAnOrder(voucherId: number, beginDate, endDate: string) {
    let orderData: searchdata;
    orderData.id = voucherId;
    orderData.beginDate = beginDate;
    orderData.endDate = endDate;
    console.log(orderData);
    this.dashboardService.makeAnOrder(orderData).subscribe((result) =>
    {
      console.log(result);
    });
  }
}
