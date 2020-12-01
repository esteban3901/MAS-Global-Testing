import { Component } from '@angular/core';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public employees: Employee[] = [];
  constructor(private employeeService: EmployeeService) { }
  //#region Functions
  
  search() {
    this.employeeService.GetAll().subscribe(resp => {
      this.employees = resp.result;
    });
  }
  searchEmployee(value: number) {
    if (value > 0) {
      this.employeeService.GetById(value).subscribe(resp => {
        this.employees = [];
        if(resp.result)
          this.employees.push(resp.result);
      });
    } else {
      this.search();
    }
  }
  //#endregion
}

//#region Model
export interface Employee {
  id: number;
  name: string;
  contractTypeName: string;
  hourlySalary: number;
  monthlySalary: number;
  annualSalary: number;
  roleName: string;
}
//#endregion
