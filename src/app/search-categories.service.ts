import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { category } from './category';
import { environment } from '../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class SearchCategoriesService {

  constructor(private httpClient:HttpClient) { }

  getCategories() : Observable<any> {
    return this.httpClient.get<any>(environment.url+ 'category');
  }
}
