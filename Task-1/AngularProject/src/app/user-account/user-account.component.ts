
import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../entity/users';

@Component({
    selector: 'user-account',
    templateUrl: './user-account.component.html',
    providers: [UserService]
})

export class UserComponent implements OnInit {
    users: User[];          // The list of users.
    total: number = 0;      // Total users.
    active: number = 0;     // Active users.
    user: User = new User();// The value of user.

    constructor(private dataService: UserService) { }

    // Initialization data.
    ngOnInit() {
        this.loadUsers();
    }

    // Finding the count of total 
    // and active users.
    setUsers() {
        this.total = this.users.length;
        this.getActiveUsers();
    }

    //  Getting active users.
    getActiveUsers() {
        this.active = 0;
        for (let el of this.users) {
            if (el.active) {
                this.active++;
            }
        }
    }

    // Loading users from database.
    loadUsers() {
        this.dataService.getUsers()
            .subscribe((data: User[]) => this.users = data);
    }

    // Saving modified user.
    save() {
        this.dataService.updateUser(this.user)
            .subscribe(data => this.loadUsers());
        this.user = new User();
    }

    // Updating data.
    changeStatus(u: User) {
        this.user = u;
        this.user.active = !this.user.active;
        this.save();
    }
}
