
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../entity/users';
import { Register } from '../entity/register';


@Injectable()
export class UserService {
    private url = "http://192.168.99.100:8080/api/users";
    constructor(private http: HttpClient) {
    }

    // Getting the list of users from home controller.
    getUsers() {
        return this.http.get(this.url);
    }

    // Updating users.
    updateUser(user: User) {
        return this.http.put(this.url, user);
    }

    CreateUser(register: Register) {
        return this.http.post("http://192.168.99.100:8080/api/account", register);
    }
}
