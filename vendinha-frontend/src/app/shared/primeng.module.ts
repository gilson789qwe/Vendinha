import { NgModule } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { PanelModule } from 'primeng/panel';
import { CardModule } from 'primeng/card';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { DialogModule } from 'primeng/dialog';
import { TableModule } from 'primeng/table';


@NgModule({
  imports: [],
  exports: [
    TableModule,
    ButtonModule,
    DynamicDialogModule,
    ConfirmDialogModule,
    DialogModule,
    CardModule,
    PanelModule,
  ],
  declarations: [],
  providers: [],
})
export class PrimengModule {}