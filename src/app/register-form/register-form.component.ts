import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment.development';
import { Observer } from 'rxjs';

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

  constructor(private http: HttpClient, private router: Router) {}

  onRegister() {
    // Creazione del payload con i dati dell'utente
    const userData = {
      name: this.name,
      surname: this.surname,
      email: this.email,
      password: this.password
    };

    const registerObserver: Observer<any> ={
      next: (response) => {
        console.log('Registrazione avvenuta con successo:', response);
        // Reindirizza l'utente alla pagina di login dopo la registrazione
        this.router.navigate(['/login']);
      },
      error: (error) => {
        const errorMessage = error?.error?.errors?.join(', ') || 'An unexpected error occurred.';
        alert('Error: ' + errorMessage);
      },
      complete:() =>{
        console.log('Registrazione avvenuta con successo');
      }
    };
    console.log('Dati registrati: ',userData);
    // Chiamata HTTP POST per inviare i dati
    this.http.post(environment.url+"User/register", userData).subscribe(registerObserver);
  }
}
