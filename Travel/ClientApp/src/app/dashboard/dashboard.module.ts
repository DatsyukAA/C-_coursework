import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }        from '@angular/forms';
import { SharedModule }       from '../shared/modules/shared.module';

import { routing }  from './dashboard.routing';
import { RootComponent } from './root/root.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';

import { AuthGuard } from '../auth.guard';
import { DashboardService } from './services/dashboard.service';
import { OrdersComponent } from './orders/orders.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    routing,
    SharedModule,
    HttpClientModule
  ],
  declarations: [RootComponent,HomeComponent, OrdersComponent],
  exports: [],
  providers: [AuthGuard, DashboardService]
})
export class DashboardModule { }
