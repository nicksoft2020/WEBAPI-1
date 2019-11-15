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
            Lastname: new FormControl(),
            Name: new FormControl(),
            Email: new FormControl(),
            Password: new FormControl()
        });

    }
    onFormSubmit() {
        const user = this.UserForm.value;
        this.Createemployee(user);
    }
    Createemployee(register: Register) {
        this.loginService.CreateUser(register).subscribe(
            data => {
                this.router.navigateByUrl('/Dashboard');
            });
        //this.loginService.CreateUser(register).subscribe(
        //    () => {
        //        this.data = true;
        //        this.massage = 'Data saved Successfully';
        //        this.UserForm.reset();
        //    });
    }
}
