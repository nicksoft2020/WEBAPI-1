
import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Register } from '../entity/register';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';
//@Component({
//  selector: 'app-login',
//  templateUrl: './login.component.html',
//  styles: []
//})
//export class LoginComponent implements OnInit {
//    formModel = {
//        Email: '',
//        Password: ''
//    }
//  constructor() { }

//  ngOnInit() {
//  }

//}
@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: []
})
export class LoginComponent {
    model: any = {};
    errorMessage: string;
    constructor(private router: Router, private LoginService: AccountService) { }
    ngOnInit() {
        sessionStorage.removeItem('UserName');
        sessionStorage.clear();
    }
    login() {
        debugger;
        this.LoginService.Login(this.model).subscribe(
            data => {
                debugger;
                if (data.Status == "Success") {
                    this.router.navigate(['/Dashboard']);
                    debugger;
                }
                else {
                    this.errorMessage = data.Message;
                }
            },
            error => {
                this.errorMessage = error.message;
            });
    };
}
