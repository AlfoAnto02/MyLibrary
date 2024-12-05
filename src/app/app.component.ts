import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'MyLibraryFE';

  constructor(){}

  load(){
    window.addEventListener('load', () => {
      document.body.style.visibility='visible';
    })
  }
}
