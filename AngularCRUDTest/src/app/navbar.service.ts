import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class NavbarService {

  constructor(private http: HttpClient) { }

  getLinks() {
    return this.http.get("https://localhost:44361/api/NavBar")
  }
}
