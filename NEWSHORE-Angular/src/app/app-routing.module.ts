import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormSearchFlightComponent } from './public/form-search-flight/form-search-flight.component';

const routes: Routes = [
  {
  path:"form-search-flight",
  component: FormSearchFlightComponent
},
{
  path:"",
  pathMatch: "full",
  redirectTo: "/form-search-flight"
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
