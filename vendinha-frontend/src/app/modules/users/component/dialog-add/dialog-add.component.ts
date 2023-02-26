import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { take } from 'rxjs';
import { Users } from 'src/app/core/models/users.model';
import { UsersService } from 'src/app/core/services/users.service';

@Component({
  selector: 'app-dialog-add',
  templateUrl: './dialog-add.component.html',
  styleUrls: ['./dialog-add.component.scss']
})
export class DialogAddComponent implements OnInit {
  id:number = 0;
  item:any = {};
  isLoading = true;

  constructor(
    private dialogConfig: DynamicDialogConfig,
    private dialogRef: DynamicDialogRef,
    private userService: UsersService

  ) {
    if (dialogConfig.data.item) {
      this.item = dialogConfig.data.item;
      this.id = dialogConfig.data.item.id;
    }

  }

  ngOnInit(): void {
   this.load();
  }

  load(){
    this.userService.getById(this.id)
    .pipe(take(1))
    .subscribe((resp:any)=>{
      this.isLoading = false;
    })
  }

}