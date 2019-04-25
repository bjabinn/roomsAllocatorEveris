import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';
import { RoomsComponent } from './rooms/rooms.component';
import { DetailsComponent } from './details/details.component';
import { SearchComponent } from './search/search.component';
import { BuildingsComponent } from './buildings/buildings.component';
import { BuildingDetailsComponent } from './building-details/building-details.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OfficesComponent } from './offices/offices.component';
import { OfficesDetailsComponent } from './offices-details/offices-details.component';
@NgModule({
  declarations: [
    AppComponent,
    RoomsComponent,
    DetailsComponent,
    SearchComponent,
    BuildingsComponent,
    BuildingDetailsComponent,
    OfficesComponent,
    OfficesDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
