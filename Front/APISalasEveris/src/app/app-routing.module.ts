import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoomsComponent } from './rooms/rooms.component';
import { DetailsComponent } from './details/details.component';
import { BuildingsComponent } from './buildings/buildings.component';
import {BuildingDetailsComponent} from './building-details/building-details.component';
import { OfficesComponent } from './offices/offices.component';
import { OfficesDetailsComponent } from './offices-details/offices-details.component';

const routes: Routes = [
  { path: 'room/index', component: RoomsComponent},
  { path: '', redirectTo: '/room/index', pathMatch: 'full' },
  { path: 'room/details/:id', component: DetailsComponent},
  { path: 'buildings/index', component: BuildingsComponent},
  { path: 'buildings/building-details/:id', component: BuildingDetailsComponent},
  { path: 'offices/index', component:OfficesComponent},
  { path: 'offices/office-details/:id', component:OfficesDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
