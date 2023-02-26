import { Component, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { filter, take } from 'rxjs';
import { Router } from '@angular/router';
import { Users } from 'src/app/core/models/users.model';
import { UsersService } from 'src/app/core/services/users.service';
import { BasePageComponent } from 'src/app/core/util/BasePageComponent';
import { dialogConfig } from 'src/app/core/configs/dialogConfig';
import { DialogAddComponent } from '../component/dialog-add/dialog-add.component';
import { DialogService } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
  providers: [DialogService],
})
export class UsersComponent extends BasePageComponent implements OnInit {
    users:Users[] = [];
    isLoading:boolean = false;
    isSearch:boolean = true;
    paramsPages: any = {
      page: 0,
      linesPerPage: 10,
    };

    constructor(
        private usersService: UsersService,
        private dialog: DialogService,
    ){
      super()
    }

    ngOnInit(): void {
      this.load(true);
    }

    loadPage(type: string){
      console.log(type)
      this.prepareType(type);
      this.load(false);
    }

    load(isSearch: boolean){
      if(isSearch==true){
        this.paginate.page = 0;
      this.paginate.linesPerPage = 10;
      }
      this.isLoading = true;
      this.paramsPages.page = this.paginate.pageNumber;
      this.paramsPages.linesPerPage = this.paginate.linesPerPage;
      this.usersService.get(this.paramsPages)
      .pipe(take(1))
      .subscribe((resp:any)=>{
        this.paginate.total = resp.serializerSettings;
        this.users = resp.value;        
        this.isLoading = false;
      }, (err)=> {
        this.isLoading = false;
      })
    }

    selectUser(value: any){
      const config = {
        header: value.instrument+' [Id: '+value.id+']',
        data: {
          item: value,
        },
        ...dialogConfig
      }
      const dialogRef = this.dialog.open(DialogAddComponent, config);
    }

    

}