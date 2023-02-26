import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { PrimengModule } from './primeng.module';
import { NotificationService } from './services/notification.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    PrimengModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    PrimengModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
  ],
  providers: [NotificationService],
  entryComponents: []
})
export class SharedModule { }
