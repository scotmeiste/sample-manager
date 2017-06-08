import { Injectable } from '@angular/core';
import { Response, Http, Headers, RequestOptions  } from '@angular/http';

import { User } from '../models/user';

@Injectable()
export class UserService {

  private userUrl = "http://localhost:63862/api/user";
  constructor(private http: Http) { }

  getUsers(): Promise<User[]> {
    return this.http.get(this.userUrl)
      .toPromise()
      .then(response => response.json() as User[]);
  }
}
