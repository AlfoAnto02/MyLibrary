import { Component, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../user-service.service';
import { Observer } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  standalone: false,
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss'
})
export class LoginFormComponent {
  @Output() loginSuccess = new EventEmitter<string>();
  email = '';
  password = '';

  constructor(private http: HttpClient, private userService: UserService, private router: Router) {}

  onSubmit() {
    const loginData = { email: this.email, password: this.password };
    const loginObserver: Observer<any> = {
      next: (response) => {
        // Naviga nella struttura della risposta per ottenere il valore di "name"
        const userName = response?.result?.result?.name;
          this.userService.login(userName);
          this.loginSuccess.emit(userName);
          this.router.navigate(['']);
      },
      error: (error) => {
        const errorMessage = error?.error?.errors?.join(', ') || 'An unexpected error occurred.';
        alert('Error: ' + errorMessage);
      },
      complete: () => {
        console.log('Login request completed.');
      }
    };
  
    console.log('Dati inviati:', loginData);
    // Usa l'osservatore nella sottoscrizione
    this.http.post(environment.url + 'User/login', loginData)
      .subscribe(loginObserver);
  }
  
  closeForm() {
    this.loginSuccess.emit("Closed");
  }
}
