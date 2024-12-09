import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class SearchBookService {

  constructor(private http: HttpClient) {}
  
  queryType:string='';
  queryData:string='';

  searchBooks(): Observable<any> {
    const filterRequest = {
      [this.queryType]: this.queryData
    };
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(environment.url+"book/filterby", filterRequest,{headers});
  }

   setType(type:string):void{
    this.queryType=type;
  }

  setData(queryData:string):void{
    this.queryData=queryData;
  }
}