import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [PagingHeaderComponent, PagerComponent],
  imports: [
    CommonModule,
    FormsModule,
    PaginationModule.forRoot()
  ],
  exports: [
    PagingHeaderComponent,
    PagerComponent,
    PaginationModule,
    FormsModule
  ]
})
export class SharedModule { }
