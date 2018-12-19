import { Component, OnInit } from '@angular/core';

import { DashboardService } from '../services/dashboard.service';
import { ivoucher, itour, searchdata } from '../../shared/models/interfacesmodels';
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
  country: string;
  hotel: string;
  resort: string;

  constructor(private dashboardService: DashboardService, private configService: ConfigService) {
    this.baseUrl = configService.getApiURI();
  }

  onChangeCountry(newValue) {
    console.log(newValue);
    this.hotel = null;
    this.country = newValue;
  }

  onChangeHotel(newValue) {
    console.log(newValue);
    this.hotel = newValue;
  }

  onChangeResort(newValue) {
    console.log(newValue);
    this.resort = newValue;
  }

  ngOnInit() {
    this.dashboardService.getToursData().subscribe((result: itour[]) =>
    {
      console.log(result);
      this.tours = result;
    });
  }

  getSearchResult()
  {
    if (this.resort != "") {
      var local_resortId = this.tours.find(tour => tour.resortName == this.resort).resortId;
      console.log(local_resortId);
      this.dashboardService.getSearchResult(local_resortId).subscribe((result: ivoucher[]) => {
        console.log(result);
        this.resultVouchers = result;
      });
    }
    else {
      console.log("not valid value");
    }
  }

  makeAnOrder(voucherId: number, beginDate, endDate: string) {
    let searchData: searchdata = { voucherId: voucherId, beginDate: beginDate, endDate: endDate }
    console.log(voucherId, beginDate, endDate);
    this.dashboardService.makeAnOrder(searchData).subscribe((result) =>
    {
      console.log(result);
    });
  }
}
