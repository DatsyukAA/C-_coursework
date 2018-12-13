import { Component, OnInit } from '@angular/core';
import { ConfigService } from '../../shared/services/ConfigService';
import { DashboardService } from '../services/dashboard.service';
import { ivoucher } from '../../shared/models/interfacesmodels';

@Component({
  selector: 'app-operator-form',
  templateUrl: './operator-form.component.html',
  styleUrls: ['./operator-form.component.css']
})
export class OperatorFormComponent implements OnInit {

  baseUrl: string = '';
  vouchers: ivoucher[];


  constructor(private dashboardService: DashboardService, private configService: ConfigService) {
    this.baseUrl = configService.getApiURI();
  }

  ngOnInit() {
    this.dashboardService.getVoucherData()
      .subscribe((result: ivoucher[]) => {
        this.vouchers = result;
    }, error => console.error(error));
  }

  changeStatus(voucher: number) {
    console.log(this.vouchers);
    this.dashboardService.changeVoucherStatus(voucher).subscribe((result: ivoucher[]) =>
    {
      this.vouchers = result;
    });
  }

  sendReport(report: string)
  {
    console.log(report);
    this.dashboardService.sendReport(report).subscribe((result) =>
    {
      console.log(result);
    });
  }

}
