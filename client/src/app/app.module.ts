import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';

import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { MaterialModule } from './material.module';
import { SignupComponent } from './auth/signup/signup.component';
import { LoginComponent } from './auth/login/login.component';
import { ArchiveComponent } from './archive/archive.component';
import { BoxesComponent } from './archive/boxes/boxes.component';
import { PoliciesComponent } from './archive/policies/policies.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { PolicyListComponent } from './policy-list/policy-list.component';
import { PolicyDetailsComponent } from './policy-details/policy-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    LoginComponent,
    ArchiveComponent,
    BoxesComponent,
    PoliciesComponent,
    WelcomeComponent,
    PolicyListComponent,
    PolicyDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
