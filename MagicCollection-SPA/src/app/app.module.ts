import { AuthGuard } from './guards/auth.guard';


import { HttpClient } from 'selenium-webdriver/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AuthService } from './Services/auth.service';

import { AppComponent } from './app.component';
import { BooksComponent } from './books/books.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './Services/error.interceptor';
import { AlertifyService } from './Services/alertify.service';
import { BsDropdownModule } from 'ngx-bootstrap';
import { EphemeraComponent } from './ephemera/ephemera.component';
import { PostersComponent } from './posters/posters.component';
import { AssetListComponent } from './asset-list/asset-list.component';
import { RouterModule } from '../../node_modules/@angular/router';
import { appRoutes } from './routes';



@NgModule({
   declarations: [
      AppComponent,
      BooksComponent,
      NavComponent,
      HomeComponent,
      BooksComponent,
      RegisterComponent,
      EphemeraComponent,
      PostersComponent,
      AssetListComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ]
,
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard
   ],
   bootstrap: [
      AppComponent
   ]
})

export class AppModule { }
