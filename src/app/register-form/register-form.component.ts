import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment.development';
import { Observer } from 'rxjs';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.scss'],
  standalone:false
})

export class RegisterFormComponent {
  name: string = '';
  surname: string = '';
  email: string = '';
  password: string = '';
  successMessage:string='';

  constructor(private authService:AuthService, private router: Router) {}

  onRegister() {
    this.authService.register(this.name,this.surname, this.email, this.password).subscribe({
      next: (response) => {
        this.successMessage='Registrazione avvenuta con successo!';
        setTimeout(() => {
          this.router.navigate(['/login']);
        },3000);
      },
      error: (error) => {
        const errorMessage = error?.error?.errors?.join(', ') || 'An unexpected error occurred.';
        alert('Error: ' + errorMessage);
      }
    });
  }
}
