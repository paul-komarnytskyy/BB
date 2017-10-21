import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './Components/app.component';
import { HomeComponent } from './Components/home.component';
import { NavbarComponent } from './Components/navbar.component';
import { CategoryFilterComponent } from './Components/category-filter.component';
import { CategoryListComponent } from './Components/category-list.component';
import { ProductFilterComponent } from './Components/product-filter.component';
import { ProductListComponent } from './Components/product-list.component';
import { PageNotFoundComponent } from './Components/page-not-found.component';

import { routing } from './app.routing';

@NgModule({
  imports:      [ BrowserModule, routing ],
  declarations: [AppComponent, NavbarComponent, CategoryFilterComponent,
      CategoryListComponent, ProductFilterComponent, ProductListComponent,
      HomeComponent, PageNotFoundComponent],
  bootstrap:    [ AppComponent ]
})

export class AppModule { }
