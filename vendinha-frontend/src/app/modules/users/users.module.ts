import { UsersRoutingModule } from './users-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './pages/users.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { DialogAddComponent } from './component/dialog-add/dialog-add.component';


@NgModule({
    declarations: [
      UsersComponent,
      DialogAddComponent
    ],
    imports: [
      CommonModule,
      UsersRoutingModule,
      SharedModule,
    ],
    exports: [
      UsersComponent
    ]
  })
  export class UsersModule { }
