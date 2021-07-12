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
import { ProgressBarComponent } from './progress-bar/progress-bar.component';
import { TradeBoardComponent } from './trade-board/trade-board.component';
import { CollectionTypesComponent } from './collection-types/collection-types.component';
import { CollectionByTypeComponent } from './collection-by-type/collection-by-type.component';
import { CollectionSupersComponent } from './collection-supers/collection-supers.component';
import { CollectionBySuperComponent } from './collection-by-super/collection-by-super.component';

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
    ProgressBarComponent,
    TradeBoardComponent,
    CollectionTypesComponent,
    CollectionByTypeComponent,
    CollectionSupersComponent,
    CollectionBySuperComponent,
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
