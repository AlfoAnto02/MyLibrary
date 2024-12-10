import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient:HttpClient) { }

  login(email: string, password : string) : Observable<any>{
    const loginData = {email,password};
    return this.httpClient.post(environment.url + 'User/Login',loginData);
  }

  register(name:string, surname:string, email: string, password: string) : Observable<any>{
    const registerData={name,surname,email,password};
    return this.httpClient.post(environment.url+"User/register", registerData)
  }

  isLoggedIn() : boolean{
    return localStorage.getItem('token') != null;
  }
}
