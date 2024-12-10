import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { book } from './book';
import { environment } from '../environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddBookService {

  constructor( private httpClient: HttpClient) { }

  addBook(book:book) : Observable<any>{
    return this.httpClient.post(environment.url+'Book/add', book);
  }
}
