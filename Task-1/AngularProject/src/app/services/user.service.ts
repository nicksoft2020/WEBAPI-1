
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../entity/users';
import { Register } from '../entity/register';


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

    CreateUser(register: Register) {
        //debugger;
        //const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        //return this.http.post<Register[]>(this.Url + "RegisterUser", register, httpOptions);
        return this.http.post("https://localhost:44334/api/account", register);
    }
}
