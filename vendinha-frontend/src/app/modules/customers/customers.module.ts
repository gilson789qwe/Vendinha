import { CustomersRoutingModule } from './customers-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomersComponent } from './pages/customers.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { DialogAddComponent } from './component/dialog-add/dialog-add.component';


@NgModule({
    declarations: [
      CustomersComponent,
      DialogAddComponent
    ],
    imports: [
      CommonModule,
      CustomersRoutingModule,
      SharedModule,
    ],
    exports: [
      CustomersComponent
    ]
  })
  export class CustomersModule { }
