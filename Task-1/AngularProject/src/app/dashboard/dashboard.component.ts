import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service'
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styles: []
})
export class DashboardComponent implements OnInit {
    userDetails: any;
    constructor(private service: AccountService) { }

    ngOnInit() {
        debugger;
        var el = localStorage.getItem('token');
        this.service.getUserProfile().subscribe(
            res => {
                debugger;
                this.userDetails = res;
            },
            err => {
                console.log(err);
            },
        );
  }

}

