import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { ServicesComponent } from './appServices/services.component';
import { SearchComponent } from './search/search.component';
import { SearchDetailsComponent } from './search-details/search-details.component';
import { AddBookComponent } from './add-book/add-book.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent }, 
  { path: 'login', component: LoginFormComponent },
  { path:'register', component: RegisterFormComponent},
  { path: 'services', component: ServicesComponent},
  { path: 'search', component: SearchComponent, canActivate: [AuthGuard]},
  { path: 'details', component:SearchDetailsComponent, canActivate: [AuthGuard]},
  { path: 'add-book', component:AddBookComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
