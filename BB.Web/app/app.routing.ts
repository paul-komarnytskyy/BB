import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './Components/home.component';
import { ProductListComponent } from './Components/product-list.component';
import { PageNotFoundComponent } from './Components/page-not-found.component';

const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'products', component: ProductListComponent },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: '**', component: PageNotFoundComponent }
]

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);