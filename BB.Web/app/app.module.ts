import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './Components/app.component';
import { HomeComponent } from './Components/home.component';
import { NavbarComponent } from './Components/navbar.component';
import { CategoryFilterComponent } from './Components/category-filter.component';
import { CategoryListComponent } from './Components/category-list.component';
import { ProductFilterComponent } from './Components/product-filter.component';
import { ProductListComponent } from './Components/product-list.component';
import { PageNotFoundComponent } from './Components/page-not-found.component';
import { UserDetailsComponent } from './Components/user-details.component';
import { LoginComponent } from './Components/login.component';

import { routing } from './app.routing';

import { AuthenticationService } from './Services/authentication.service';
import { UserService } from './Services/user.service';
import { BaseRequestOptions } from '@angular/http';

import { AuthGuard } from './Guards/auth.guard';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing
    ],

    declarations: [
        AppComponent,
        NavbarComponent,
        CategoryFilterComponent,
        CategoryListComponent,
        ProductFilterComponent,
        ProductListComponent,
        HomeComponent,
        PageNotFoundComponent,
        UserDetailsComponent,
        LoginComponent
    ],

    bootstrap: [
        AppComponent
    ],

    providers: [
        AuthGuard,
        AuthenticationService,
        UserService,
        BaseRequestOptions
    ]
})

export class AppModule { }
