import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';    
import { Register } from '../entity/register';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';



@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: []
})
export class RegisterComponent implements OnInit {
    data = false;
    UserForm: any;
    massage: string;

    constructor(private formbulider: FormBuilder, private router: Router, private loginService: AccountService) { }
    ngOnInit() {
        this.UserForm = new FormGroup({
            "Lastname": new FormControl("", [Validators.required, Validators.pattern("[A-Z][a-z]+")]),
            "Name": new FormControl("", [Validators.required, Validators.pattern("[A-Z][a-z]+")] ),
            "Email": new FormControl("", [Validators.required, Validators.email]),
            "Password": new FormControl("", [Validators.required])
        });

    }
    onFormSubmit() {
        const user = this.UserForm.value;
        this.Createemployee(user);
    }
    Createemployee(register: Register) {
        debugger;
        this.loginService.CreateUser(register).subscribe(
            data => {
                debugger;
                this.router.navigateByUrl('/login');
            });
        this.router.navigateByUrl('/login');
    }
}
