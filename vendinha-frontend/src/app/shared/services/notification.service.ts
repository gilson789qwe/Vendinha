import { Injectable } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Subject } from 'rxjs';

@Injectable({providedIn: 'root'})
export class NotificationService {
  _dialogConfirm$ = new Subject<boolean>();
  constructor(private messageService: MessageService, private confirmationService: ConfirmationService) { }

  success(title: string, message: string, time: number = 3000): void {
    this.messageService.add({severity:'success', summary: title, detail: message, life: time});
  }
  info(title: string, message: string, time: number = 3000): void {
    this.messageService.add({severity:'info', summary: title, detail: message, life: time});
  }
  warn(title: string, message: string, time: number = 3000): void {
    this.messageService.add({severity:'warn', summary: title, detail: message, life: time});
  }
  error(title: string, message: string, time: number = 3000): void {
    this.messageService.add({severity:'error', summary: title, detail: message, life: time});
  }
  custom(title: string, message: string, time: number = 3000): void {
    this.messageService.add({severity:'custom', summary: title, detail: message, life: time});
  }

}
