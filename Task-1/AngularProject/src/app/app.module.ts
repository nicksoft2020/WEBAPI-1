//import { BrowserModule } from '@angular/platform-browser';
//import { NgModule } from '@angular/core';
//import { FormsModule, ReactiveFormsModule } from "@angular/forms";
//import { AppComponent } from './app.component';
//import { UserAccountComponent } from './user-account/user-account.component';

//@NgModule({
//  declarations: [
//    AppComponent,
//    UserAccountComponent
//  ],
//  imports: [
//      BrowserModule,
//      FormsModule,
//      ReactiveFormsModule
//  ],
//  providers: [],
//  bootstrap: [AppComponent]
//})
//export class AppModule { }

//import { NgModule } from '@angular/core';
//import { BrowserModule } from '@angular/platform-browser';
//import { FormsModule } from '@angular/forms';
//import { HttpClientModule } from '@angular/common/http';
//import { AppComponent } from './app.component';

//@NgModule({
//    imports: [BrowserModule, FormsModule, HttpClientModule],
//    declarations: [AppComponent],
//    bootstrap: [AppComponent]
//})
//export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { UserComponent } from './user-account/user-account.component';
import { HttpClientModule } from '@angular/common/http';

//import { MatDialogModule } from '@angular/material';
//import { DialogBodyComponent } from "./dialog-body/dialog-body.component";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { UserComponent } from './user-account/user.component';



@NgModule({
    declarations: [
        AppComponent,
        AppComponent,
        UserComponent,
        //DialogBodyComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        //MatDialogModule,
        BrowserAnimationsModule
    ],
    providers: [],
    bootstrap: [AppComponent],
    //entryComponents: [DialogBodyComponent]
})
export class AppModule { }
