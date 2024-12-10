import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { json } from 'express';
import { SearchBookService } from '../search-book.service';

@Component({
  selector: 'app-search',
  templateUrl: './search-details.component.html',
  styleUrl: './search-details.component.scss',
  standalone:false
})
export class SearchDetailsComponent {
  query: string = ''; 
  filteredBooks: any[] = []; 
  isLoading: boolean = false;
  errorMessage: string = '';
  payload:string="";

  constructor(private route: ActivatedRoute, private searchService: SearchBookService) {}

  onSearch(): void {
    if (!this.query.trim()) {
      this.errorMessage = 'Inserisci un valore di ricerca.';
      this.filteredBooks=[];
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';
    this.searchService.setData(this.query);



    this.searchService.searchBooks().subscribe({
      next: (response) => {
        this.filteredBooks = response?.result?.books || []; 
        this.isLoading = false;

        if (this.filteredBooks.length === 0) {
          this.errorMessage = 'Nessun risultato trovato.';
        }
      },
      error: (error) => {
        this.errorMessage = 'Errore durante la ricerca.';
        console.error(error);
        this.isLoading = false;
      }
    });
  }
}
