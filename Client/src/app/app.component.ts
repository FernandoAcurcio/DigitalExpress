import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './Models/product';
import { Pagination } from './Models/pagination';
import { response } from 'express';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Digital Express';
  products: IProduct[] = [];

  // inject into a angular component
  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.http.get<Pagination<IProduct[]>>('https://localhost:5001/api/products?pageSize=50').subscribe({
      next: response => this.products = response.data, // what to do next
      error: error => console.log(error), // handle error
      // automatically unsubscribe after receiving the request
      complete: () => {
        console.log('request completed');
        console.log('another thing');
        // on complete unsubscribe automatically
      }
    })
  }
}
