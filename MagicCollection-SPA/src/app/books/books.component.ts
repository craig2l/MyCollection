import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
    selector: 'app-books';
    books: any;
    constructor(private http: HttpClient) { }

    ngOnInit() {
        this.getBooks();
    }

    getBooks() {
        this.http.get('http://localhost:28906/api/books/getbooks').subscribe(
            response => this.books = response,
            error => console.log(error)
        );
    }

}
