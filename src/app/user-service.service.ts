import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private userNameSource = new BehaviorSubject <string | null> (null);
  userName$ = this.userNameSource.asObservable();

  login(userName:string) : void{
    this.userNameSource.next(userName);
  }

  logout(): void {
    this.userNameSource.next(null);
  }
}