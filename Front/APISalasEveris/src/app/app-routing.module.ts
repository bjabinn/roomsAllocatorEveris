import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoomsComponent } from './rooms/rooms.component';
import { DetailsComponent } from './details/details.component';
import { BuildingsComponent } from './buildings/buildings.component';

const routes: Routes = [
  { path: 'room/index', component: RoomsComponent},
  { path: '', redirectTo: '/room/index', pathMatch: 'full' },
  { path: 'room/details/:id', component: DetailsComponent},
  { path: 'buildings/index', component: BuildingsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
