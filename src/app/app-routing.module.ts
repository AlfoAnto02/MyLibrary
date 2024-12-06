import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { ServicesComponent } from './services/services.component';
import { SearchComponent } from './search/search.component';
import { AddComponent } from './add/add.component';
import { SearchDetailsComponent } from './search-details/search-details.component';

const routes: Routes = [
  { path: '', component: HomeComponent }, 
  { path: 'login', component: LoginFormComponent },
  { path:'register', component: RegisterFormComponent},
  {path: 'services', component: ServicesComponent},
  {path: 'search', component: SearchComponent},
  {path: 'add', component: AddComponent},
  {path: 'details', component:SearchDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
