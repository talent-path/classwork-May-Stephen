import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CardDetailComponent } from './card-detail/card-detail.component';
import { CardService } from 'src/services/card-service';
import { CardListComponent } from './card-list/card-list.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import {  SeriesListComponent } from './series-list/series-list.component';
import { SetTrackerComponent } from './set-tracker/set-tracker.component';
import { AlertComponent } from './alert/alert.component';
import { LoginLogoutComponent } from './login-logout/login-logout.component';
import { CollectionViewComponent } from './collection-view/collection-view.component';
import { CollectionListComponent } from './collection-list/collection-list.component';
import { AddToCollectionComponent } from './add-to-collection/add-to-collection.component';

@NgModule({
  declarations: [
    AppComponent,
    CardDetailComponent,
    CardListComponent,
    NavbarComponent,
    FooterComponent,
    SetTrackerComponent,
    SeriesListComponent,
    AlertComponent,
    LoginLogoutComponent,
    CollectionViewComponent,
    CollectionListComponent,
    AddToCollectionComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    
  ],
  providers: [CardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
