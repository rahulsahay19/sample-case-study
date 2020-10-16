import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';

// Shared module is going to have singleton service kind of things like nav-bar

@NgModule({
  declarations: [NavBarComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NavBarComponent
  ]
})
export class CoreModule { }
