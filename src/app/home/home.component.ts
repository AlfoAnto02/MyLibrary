import { Component, OnInit } from '@angular/core';
import { UserService } from '../user-service.service';

@Component({
  selector: 'app-home',
  standalone: false,
  
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  userName: string | null = null;

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userName = this.userService.getUserName();
  }

  onLogout() {
    // Rimuovi i dati utente dal localStorage
    this.userService.setUserName('');
    this.userName = null;
  }
}
