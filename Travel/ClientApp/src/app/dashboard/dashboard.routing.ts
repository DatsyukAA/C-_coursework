import { ModuleWithProviders } from '@angular/core';
import { RouterModule }        from '@angular/router';

import { RootComponent }    from './root/root.component';
import { HomeComponent } from './home/home.component';
import { OrdersComponent } from './orders/orders.component';

import { AuthGuard } from '../auth.guard';
import { OperatorFormComponent } from './operator-form/operator-form.component';
import { UserFormComponent } from './user-form/user-form.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
  {
      path: 'dashboard',
      component: RootComponent, canActivate: [AuthGuard],

      children: [      
       { path: '', component: HomeComponent },
        { path: 'home', component: HomeComponent },
        { path: 'orders', component: OrdersComponent },
        { path: 'operator-form', component: OperatorFormComponent },
        { path: 'user-form', component: UserFormComponent }
      ]       
    }  
]);
