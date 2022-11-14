import { Employee } from './../../shared/models/employee.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { EmployeeService } from 'src/app/shared/services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  providers: [ EmployeeService ]
})
export class EmployeeListComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'birthDate', 'gender', 'email', 'cpf', 'startDate', 'team'];
  employees: Employee[] = [];

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.employeeService.getEmployees().subscribe(resp => {
      console.log(resp);
      this.employees = resp;
    });
  }
}
