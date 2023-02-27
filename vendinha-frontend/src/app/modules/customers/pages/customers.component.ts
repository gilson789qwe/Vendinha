import { Component, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { filter, take } from 'rxjs';
import { Router } from '@angular/router';
import { Customers } from 'src/app/core/models/customers.model';
import { CustomersService } from 'src/app/core/services/customers.service';
import { BasePageComponent } from 'src/app/core/util/BasePageComponent';
import { dialogConfig } from 'src/app/core/configs/dialogConfig';
import { DialogAddComponent } from '../component/dialog-add/dialog-add.component';
import { DialogService } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
  providers: [DialogService],
})
export class CustomersComponent extends BasePageComponent implements OnInit {
    customers:Customers[] = [];
    isLoading:boolean = false;
    isSearch:boolean = true;
    paramsPages: any = {
      page: 0,
      linesPerPage: 10,
    };

    constructor(
        private customersService: CustomersService,
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
      this.customersService.get(this.paramsPages)
      .pipe(take(1))
      .subscribe((resp:any)=>{
        this.paginate.total = resp.serializerSettings;
        this.customers = resp.value;        
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