import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './Components/app.component';
import { NavbarComponent } from './Components/navbar.component';
import { CategoryFilterComponent } from './Components/category-filter.component';
import { CategoryListComponent } from './Components/category-list.component';
import { ProductFilterComponent } from './Components/product-filter.component';
import { ProductListComponent } from './Components/product-list.component';

@NgModule({
  imports:      [ BrowserModule ],
  declarations: [AppComponent, NavbarComponent, CategoryFilterComponent,
      CategoryListComponent, ProductFilterComponent, ProductListComponent],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
