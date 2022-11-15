import { Employee } from './../../shared/models/employee.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { EmployeeService } from 'src/app/shared/services/employee.service';
import { MatDialog } from '@angular/material/dialog';
import { EmployeeFormComponent } from '../employee-form/employee-form.component';
import { ConfirmModalComponent } from '../confirm-modal/confirm-modal.component';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'birthDate', 'gender', 'email', 'cpf', 'startDate', 'team', 'action'];
  employees: Employee[] = [];

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private employeeService: EmployeeService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.getEmployees();
  }

  form(row: any, msg: string) {
    let dialogRef = this.dialog.open(EmployeeFormComponent, {
      data: {employee: row, msg: msg }
    });

    dialogRef.afterClosed().subscribe(res => {
      this.getEmployees();
    });
  }

  deleteEmployee(row: any){
    let dialogRef = this.dialog.open(ConfirmModalComponent, {
      data: {employee: row }
    });

    dialogRef.afterClosed().subscribe(res => {
      this.getEmployees();
    });
  }

  getEmployees() {
    this.employeeService.getEmployees().subscribe(resp => {
      this.employees = resp;
    });
  }
}
