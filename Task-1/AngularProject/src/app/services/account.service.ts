import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Register } from '../entity/register';

@Injectable({
  providedIn: 'root'
})


export class AccountService {
    Url: string;
    token: string;
    header: any;
    constructor(private http: HttpClient) {
        //this.Url = "https://localhost:44334/api/account";
        this.Url = "http://192.168.99.100:8080/api/users";
        const headerSettings: { [name: string]: string | string[]; } = {};
        this.header = new HttpHeaders(headerSettings);
    }

    Login(model: any) {
        return this.http.post<any>(this.Url + "/LoginUser", model, { headers: this.header });
    }

    LogOff() {
        return this.http.get(this.Url + "/LogoutUser");
    }

    CreateUser(register: Register) {
        return this.http.post(this.Url + "/RegisterUser", register);
    }

    getUserProfile() {
        var tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });
        debugger;
        return this.http.get("http://192.168.99.100:8080/api/profile/GetProfile", { headers: tokenHeader });
    }
}
