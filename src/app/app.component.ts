import { Component, OnInit } from '@angular/core';
import { UserService } from './user-service.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'MyLibraryFE';

  userName: string | null = null;
  isMenuOpen: boolean = false;

  constructor(private userService: UserService){
    this.userService.userName$.subscribe(name =>{
      this.userName=name;
    })
  }

  onLogout() {
    this.userService.logout();
  }

  toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen; 
  }
}
