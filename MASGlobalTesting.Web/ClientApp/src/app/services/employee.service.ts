import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../home/home.component';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }
  //#region Methods
  GetAll() {
    return this.http.get<ResponseList>(this.baseUrl + 'employee');
  }
  GetById(id: number) {
    return this.http.get<Response>(this.baseUrl + 'employee/' + id);
  }
  //#endregion
}
//#region Interfaces
interface ResponseList {
  Status: boolean;
  result: Employee[];
}

interface Response {
  Status: boolean;
  result: Employee;
}
//#endregion
