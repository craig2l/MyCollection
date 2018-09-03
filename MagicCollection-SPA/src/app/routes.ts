import { HomeComponent } from './home/home.component';
import {Routes} from '@angular/router';
import { AssetListComponent } from './asset-list/asset-list.component';
import { BooksComponent } from './books/books.component';
import { PostersComponent } from './posters/posters.component';
import { EphemeraComponent } from './ephemera/ephemera.component';
import { AuthGuard } from './guards/auth.guard';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'assetlist', component: AssetListComponent},
            { path: 'books', component: BooksComponent},
            { path: 'posters', component: PostersComponent},
            { path: 'ephemera', component: EphemeraComponent},
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'}
];
