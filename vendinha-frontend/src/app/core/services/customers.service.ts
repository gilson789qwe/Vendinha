import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customers } from '../models/customers.model';

@Injectable({providedIn: 'root'})
export class CustomersService {
  base_url: string = `http://localhost:5217/customers`;
  constructor(private httpClient: HttpClient) { }

  prepareParams(paramsObj:any): HttpParams {
      let searchParams = new HttpParams();
      for(let key in paramsObj){
          if(paramsObj.hasOwnProperty(key)){
              searchParams = searchParams.append(key, paramsObj[key]);
          }
      }
      return searchParams;
  }

  get(payload:any): Observable<Customers[]> {
    return this.httpClient.get<Customers[]>(this.base_url, {
      params: this.prepareParams(payload)
    });
  }

  getById(id:number): Observable<Customers[]> {
    return this.httpClient.get<Customers[]>(this.base_url+`/${id}`);
  }
}