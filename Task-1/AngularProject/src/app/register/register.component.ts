import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';    
import { Register } from '../entity/register';
import { AccountService } from '../services/account.service';


@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: []
})
export class RegisterComponent implements OnInit {
    data = false;
    UserForm: any;
    massage: string;

    constructor(private formbulider: FormBuilder, private loginService: AccountService) { }
    ngOnInit() {
        //this.UserForm = this.formbulider.group({
        //    Lastname: ['', [Validators.required]],
        //    Name: ['', [Validators.required]],
        //    Email: ['', [Validators.required]],
        //    Password: ['', [Validators.required]],
        //});
        this.UserForm = new FormGroup({
            Lastname: new FormControl(),
            Name: new FormControl(),
            Email: new FormControl(),
            Password: new FormControl()
        });

        //formModel = this.fb.group({
        //      Lastname: ['', [Validators.required]],
        //      Name: ['', [Validators.required]],
        //      Email: ['', [Validators.required]],
        //      Password: ['', [Validators.required]],
        //    Passwords: this.fb.group({
        //        Password: ['', [Validators.required, Validators.minLength(4)]],
        //        ConfirmPassword: ['', Validators.required]
        //    }, { validator: this.comparePasswords });
    }
    onFormSubmit() {
        const user = this.UserForm.value;
        this.Createemployee(user);
    }
    Createemployee(register: Register) {
        this.loginService.CreateUser(register).subscribe(
            () => {
                this.data = true;
                this.massage = 'Data saved Successfully';
                this.UserForm.reset();
            });
    }
}



//@Component({
//  selector: 'app-register',
//  templateUrl: './register.component.html',
//  styles: []
//})
//export class RegisterComponent implements OnInit{


    //register: Register = new Register();
    //message: string;

    //constructor(private accountService: AccountService) { }

    //ngOnInit() {

    //}

    //registerUser() {
    //    if (this.register != null) {
    //        this.accountService.createUser(this.register).subscribe(
    //            () => {
    //                this.message = 'Data saved Successfully';
    //            });
    //    }
    //}
    ////////////////////////////////////////////////////////////////
    //
    //data = false;
    //UserForm: any;
    //massage: string;
    //constructor(private formbulider: FormBuilder, private loginService: LoginService) { }
    //ngOnInit() {
    //    this.UserForm = this.formbulider.group({
    //        Lastname: ['', Validators.required],
    //        Name: ['', [Validators.required]],
    //        Email: ['', [Validators.required]],
    //        Password: ['', [Validators.required]]
    //    });
    //}
    //onFormSubmit() {
    //    const user = this.UserForm.value;
    //    this.Createemployee(user);
    //}
    //Createemployee(register: Register) {
    //    this.loginService.CreateUser(register).subscribe(
    //        () => {
    //            this.data = true;
    //            this.massage = 'Data saved Successfully';
    //            this.UserForm.reset();
    //        });
    //}    

//}
