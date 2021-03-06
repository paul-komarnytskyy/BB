import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './Components/app.component';
import { HomeComponent } from './Components/home.component';
import { NavbarComponent } from './Components/navbar.component';
import { CharacteristicsFilterComponent } from './Components/characteristics-filter.component';
import { CategoryListComponent } from './Components/category-list.component';
import { ProductFilterComponent } from './Components/product-filter.component';
import { ProductListComponent } from './Components/product-list.component';
import { OrderHistoryComponent } from './Components/order-history.component';
import { PageNotFoundComponent } from './Components/page-not-found.component';
import { UserDetailsComponent } from './Components/user-details.component';
import { LoginComponent } from './Components/login.component';
import { FilterItemComponent } from './Components/filter-item.component';
import { RegisterComponent } from './Components/register.component';
import { DetailsComponent } from './Components/details.component';
import { AdminComponent } from './Components/admin.component';
import { CartComponent } from './Components/cart.component';
import { OrderComponent } from './Components/order.component';
//import { ModalComponent } from './Components/modal.component';

import { routing } from './app.routing';

import { AdminService } from './Services/admin.service';
import { AuthenticationService } from './Services/authentication.service';
import { UserService } from './Services/user.service';
import { CategoriesService } from './Services/categories.service';
import { CharacteristicsService } from './Services/characteristics.service';
import { OrdersService } from './Services/orders.service';
import { ProductsService } from './Services/products.service';
import { DetailsService } from './Services/details.service';
//import { ModalService } from './Services/modal.service';

import { BaseRequestOptions } from '@angular/http';

import { AuthGuard } from './Guards/auth.guard';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing,
    ],

    declarations: [
        AppComponent,
        NavbarComponent,
        CharacteristicsFilterComponent,
        CategoryListComponent,
        ProductFilterComponent,
        ProductListComponent,
        OrderHistoryComponent,
        HomeComponent,
        PageNotFoundComponent,
        UserDetailsComponent,
        LoginComponent,
        FilterItemComponent,
        RegisterComponent,
        DetailsComponent,
        CartComponent,
        //ModalComponent,
        OrderComponent,
        AdminComponent
    ],

    bootstrap: [
        AppComponent
    ],

    providers: [
        AuthGuard,
        AdminService,
        AuthenticationService,
        CategoriesService,
        CharacteristicsService,
        OrdersService,
        ProductsService,
        UserService,
        DetailsService,
        //ModalService,
        BaseRequestOptions
    ]
})

export class AppModule { }
