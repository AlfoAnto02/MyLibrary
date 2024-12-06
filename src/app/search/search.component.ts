import { Component } from '@angular/core';
import { SearchBookService } from '../search-book.service';

@Component({
  selector: 'app-search',
  standalone: false,
  
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss'
})
export class SearchComponent {

  constructor(private searchBook:SearchBookService){}

  onAuthor(){
    this.searchBook.setType("author");
  }

  onGenre(){
    this.searchBook.setType("categoryName")
  }

  onTitle(){
    this.searchBook.setType("bookName")
  }
}
