import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RegisterFormComponent } from './register-form/register-form.component';
import { ServicesComponent } from './services/services.component';
import { SearchComponent } from './search/search.component';
import { AddComponent } from './add/add.component';
import { SearchDetailsComponent } from './search-details/search-details.component';
import { AuthInterceptor } from './auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginFormComponent,
    RegisterFormComponent,
    ServicesComponent,
    SearchComponent,
    AddComponent,
    SearchDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    
    HttpClientModule
  ],
  providers: [
    {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
  }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }