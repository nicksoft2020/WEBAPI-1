//import { Injectable } from '@angular/core';

//@Injectable({
//  providedIn: 'root'
//})
//export class UserService {

//  constructor() { }
//}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../entity/users';

@Injectable()
export class UserService {
    private url = "https://localhost:44334/api/users";

    constructor(private http: HttpClient) {
    }

    // Getting the list of users from home controller.
    getUsers() {
        return this.http.get(this.url);
    }

    // Updating users.
    updateUser(user: User) {
        return this.http.put(this.url + '/' + user.id, user);
    }
}
