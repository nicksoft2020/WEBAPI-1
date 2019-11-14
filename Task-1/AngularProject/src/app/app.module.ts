import { Routes, RouterModule } from '@angular/router'; 

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { UserComponent } from './user-account/user-account.component';
import { HttpClientModule } from '@angular/common/http';


import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';

export const routes: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full', },
    { path: 'login', component: LoginComponent, data: { title: 'Login Page' } },
    { path: 'Dasboard', component: DashboardComponent, data: { title: 'Dashboard Page' } },
    { path: 'AddUser', component: RegisterComponent, data: { title: 'Add User Page' } },
]; 

@NgModule({
    declarations: [
        AppComponent,
        AppComponent,
        UserComponent,
        LoginComponent,
        RegisterComponent,
        DashboardComponent,
        
    ],
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        RouterModule.forRoot(routes),
        BrowserAnimationsModule
    ],
    exports: [RouterModule],
    providers: [],
    bootstrap: [AppComponent, RegisterComponent, LoginComponent],
    //entryComponents: [RegisterComponent]
})
export class AppModule { }
