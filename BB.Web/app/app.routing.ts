import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './Components/home.component';
import { ProductListComponent } from './Components/product-list.component';
import { CategoryListComponent } from './Components/category-list.component';
import { DetailsComponent } from './Components/details.component';
import { RegisterComponent } from './Components/register.component';
import { PageNotFoundComponent } from './Components/page-not-found.component';

import { AuthGuard } from './Guards/auth.guard';
import { UserDetailsComponent } from './Components/user-details.component';
import { OrderComponent } from './Components/order.component';

const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'products', component: ProductListComponent },
    { path: 'categories', component: CategoryListComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'details/:id', component: DetailsComponent },
    { path: 'order/:id', component: OrderComponent},
    { path: 'user-details', component: UserDetailsComponent, canActivate: [AuthGuard] },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: '**', component: PageNotFoundComponent }
]

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);