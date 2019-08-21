import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './Login/Login.component';
import { RegistrationComponent } from './registration/registration.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
    ],
  declarations: [
    LoginComponent,
    RegistrationComponent],
  exports: [
    LoginComponent,
    RegistrationComponent
  ]
})
export class UserModule { }
