import { Component } from '@angular/core';
import { AccountService } from './services/account.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent {
    isLogined: boolean = false;
    fullName: string;
    title = 'AngularProject';

    constructor(private router: Router, private LoginService: AccountService) { }

    
    LoginedUser(name: string) {
        debugger;
        this.fullName = name;
        this.isLogined = true;
    }

    LogoutUser() {
        this.isLogined = false;
    }

    logOff() {
        this.LoginService.LogOff().subscribe(
            () => {
                this.router.navigateByUrl('/user');
                this.LogoutUser();
            });
    }
}

