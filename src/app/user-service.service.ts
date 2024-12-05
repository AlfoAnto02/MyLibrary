import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private userName: string | null = null;

  setUserName(userName: string) {
    this.userName = userName;
  }

  getUserName(): string | null {
    return this.userName;
  }
}