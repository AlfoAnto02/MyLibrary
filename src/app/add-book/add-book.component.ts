import { Component, OnInit } from '@angular/core';
import { category } from '../category';
import { book } from '../book';
import { SearchCategoriesService } from '../search-categories.service';
import { AddBookService } from '../add-book.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.scss'],
  standalone: false
})
export class AddBookComponent implements OnInit {

  categories?: category [];
  book: book = {
    title: '',
    author: '',
    publication_Date: '',
    publisher: '',
    categoriesIds: [] 
  };
  successMessage:string='';
  errorMessage:string='';

  constructor(private categoryService:SearchCategoriesService, private addBookService:AddBookService) {}

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe({
      next:(data) =>{
        this.categories=data.result.entities;
      },
      error:(error) => {
        console.error('Errore nel recuperare le categorie: ', error)
      }
    })
  }


  onSubmit(): void {
    this.addBookService.addBook(this.book).subscribe({
      next: (response)=>{
        this.successMessage='Libro aggiunto con successo: ';
      },
      error: (error) =>{
        this.errorMessage='Errore durante l\'aggiunta del libro: ' + error?.error?.errors;
      }
    });
  }
}