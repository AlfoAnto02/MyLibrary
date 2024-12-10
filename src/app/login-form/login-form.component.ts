import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user-service.service';
import { AuthService } from '../auth.service';

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
  errorMessage: string ='';

  constructor(private authService:AuthService, private userService: UserService, private router: Router) {}

  onSubmit() {
    console.log('Dati inviati:', { email: this.email, password: this.password });
    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        const userName = response?.result?.user?.name;
        this.userService.login(userName);
        this.loginSuccess.emit(userName);
        localStorage.setItem('token', response?.result?.token);
        this.router.navigate(['']);
      },
      error: (error) => {
        this.errorMessage = error?.error?.errors?.join(', ') || 'An unexpected error occurred.';
        localStorage.removeItem('token');
      }
    });
  }

  closeForm() {
    this.loginSuccess.emit('Closed');
  }
}
