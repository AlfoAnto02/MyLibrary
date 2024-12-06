import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RegisterFormComponent } from './register-form/register-form.component';
import { ServicesComponent } from './services/services.component';
import { SearchComponent } from './search/search.component';
import { AddComponent } from './add/add.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginFormComponent,
    RegisterFormComponent,
    ServicesComponent,
    SearchComponent,
    AddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
