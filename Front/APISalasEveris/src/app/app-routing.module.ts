import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoomsComponent } from './rooms/rooms.component';
import { DetailsComponent } from './details/details.component';

const routes: Routes = [
  { path: 'api/index', component: RoomsComponent},
  { path: '', redirectTo: '/api/index', pathMatch: 'full' },
  { path: 'api/details/:id', component: DetailsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
