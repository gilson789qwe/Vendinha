import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Users } from '../models/users.model';

@Injectable({providedIn: 'root'})
export class UsersService {
  base_url: string = `http://localhost:5217/users`;
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

  get(payload:any): Observable<Users[]> {
    return this.httpClient.get<Users[]>(this.base_url, {
      params: this.prepareParams(payload)
    });
  }

  getById(id:number): Observable<Users[]> {
    return this.httpClient.get<Users[]>(this.base_url+`/${id}`);
  }
}