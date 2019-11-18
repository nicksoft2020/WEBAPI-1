
import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Register } from '../entity/register';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';
import { AppComponent } from '../app.component';
import { Login } from '../entity/login'

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: []
})

export class LoginComponent implements OnInit {
    LoginForm: any;
    model: any = {};
    errorMessage: string;
    fullname: string;

    constructor(private router: Router, private AppComp: AppComponent, private LoginService: AccountService) { }

    ngOnInit() {
        //if (localStorage.getItem('token') != null)
        //    this.router.navigateByUrl('/Dashboard');

        this.LoginForm = new FormGroup({
            "Email": new FormControl("", [Validators.required, Validators.email]),
            "Password": new FormControl("", [Validators.required])
        });
        sessionStorage.removeItem('UserName');
        sessionStorage.clear();
    }

    login(login: Login) {
        this.LoginService.Login(login).subscribe(
            (res: any) => {
                this.AppComp.LoginedUser();
                localStorage.setItem('token', res.token);
                this.router.navigateByUrl('/Dashboard');
                
            },
            (err) => {
                if (err.status == "404") {
                    this.errorMessage = "There is invalid email or password!";
                }
            }

        );
            //data => {
            //    if (data.status == "Success") {
            //        debugger;
            //        localStorage.setItem('token', data.message);
            //        debugger;
            //        this.router.navigateByUrl('/Dashboard');
            //        debugger;
            //        this.AppComp.LoginedUser(data.fullname);
            //    }
            //    else {
            //        this.errorMessage = data.Message;
            //    }
            //},
            //error => {
            //    this.errorMessage = error.message;
            //});
    };

    
}
