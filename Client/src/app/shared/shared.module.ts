import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    PaginationModule.forRoot() // this is being used as a singleton, it's what happens when we use pagination
  ],
  exports: [
    PaginationModule
  ]
})
export class SharedModule { }
