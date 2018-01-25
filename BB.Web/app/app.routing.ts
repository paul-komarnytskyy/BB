import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './Components/home.component';
import { ProductListComponent } from './Components/product-list.component';
import { CategoryListComponent } from './Components/category-list.component';
import { DetailsComponent } from './Components/details.component';
import { RegisterComponent } from './Components/register.component';
import { AdminComponent } from './Components/admin.component';
import { UserDetailsComponent } from './Components/user-details.component';
import { PageNotFoundComponent } from './Components/page-not-found.component';
import { CartComponent } from './Components/cart.component';

import { AuthGuard } from './Guards/auth.guard';

const appRoutes: Routes = [
    { path: 'details/:id', component: DetailsComponent },
    { path: 'home', component: HomeComponent },
    { path: 'products', component: ProductListComponent },
    { path: 'categories', component: CategoryListComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
    { path: 'user-details', component: UserDetailsComponent, canActivate: [AuthGuard] },
    { path: 'cart', component: CartComponent, canActivate: [AuthGuard]  },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: '**', component: PageNotFoundComponent }
]

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);