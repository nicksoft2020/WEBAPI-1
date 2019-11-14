import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent {
    btnRegister: boolean = false;
    btnLogin: boolean = false;
    btnShowUsers: boolean = true;

    register() {
        this.btnShowUsers = false;
        this.btnLogin = false;
        this.btnRegister = true;
    }

    login() {
        this.btnShowUsers = false;
        this.btnRegister = false;
        this.btnLogin = true;
    }

    showUsers() {
        this.btnRegister = false;
        this.btnLogin = false;
        this.btnShowUsers = true;
        
    }

  title = 'AngularProject';
}

